#nullable disable

using RevisionTwo_App.Auxillary;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

using Acumatica.Auth.Api;
using Acumatica.RESTClient.Model;
using Acumatica.Default_20_200_001.Api;
using Acumatica.Default_20_200_001.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using static RevisionTwo_App.Models.Default;
using static RevisionTwo_App.Models.App;
using static RevisionTwo_App.Models.Model_Conversion;

namespace RevisionTwo_App.Areas.Demo.Pages.SalesOrders;

[BindProperties(SupportsGet = true)]
public class IndexModel : PageModel
{
    #region ctor
    private readonly ILogger<IndexModel> _logger;
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }
    #endregion

    /// <summary>
    /// Credentials list of credentials in db
    /// </summary>
    public List<Credential> Credentials { get; set; }

    #region Bound Model Properties
    /// <summary>
    /// Salesorder list retrieved from SalesOrder Model <see cref="Endpoint" />"
    /// </summary>
    public Address BillToAddress { get; set; }
    public DocContact BillToContact { get; set; }
    public Commissions Commission { get; set; }
    public List<SalesOrder> SalesOrders { get; set; }
    public List<SalesOrderDetail> SalesOrderDetails { get; set; }
    public List<SalesOrdersDiscountDetails> DiscountDetails { get; set; }
    public FinancialSettings FinancialSettings { get; set; }
    public List<SalesOrderPayment> Payments { get; set; }
    public List<SalesOrderShipment> SalesOrderShipments { get; set; }
    public ShippingSettings ShippingSettings { get; set; }
    public Address ShipToAddress { get; set; }
    public DocContact ShipToContact { get; set; }
    public List<TaxDetail> TaxDetails { get; set; }
    public Totals Totals { get; set; }
    public BusinessAccount BusinessAccount { get; set; }
    public List<CustomSalesOrderInfo> CustomSalesOrderInfo { get; set; }
    public bool salesOrdersRetrieved { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FromDate { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ToDate { get; set; } = DateTime.Now;
    #endregion

    #region methods
    /// <summary>
    /// Retrieve list of the most recent 10 SalesOrders
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {

        Credentials = await _context.Credentials.ToListAsync();

        int id = new AuthId().getAuthId(Credentials);

        AuthApi authApi = new AuthApi(Credentials[id].SiteUrl,
            requestInterceptor: RequestLogger.LogRequest, responseInterceptor: RequestLogger.LogResponse);

        if (authApi is null)
        {
            _logger.LogError($"Failure to create an authAPI context. SiteURL is {Credentials[id].SiteUrl} and id is {id}");
            Console.WriteLine($"Failure to create an authAPI context. SiteURL is {Credentials[id].SiteUrl} and id is {id}");
            throw new NullReferenceException(nameof(authApi));
        }

        try
        {
            Acumatica.RESTClient.Client.Configuration configuration = authApi.LogIn(Credentials[id].UserName, Credentials[id].Password, "", "", "");

            if (configuration is null)
            {
                _logger.LogError($"Failure to create an configuration context. authApi.Login has UserName of {Credentials[id].UserName} and Password of {Credentials[id].Password}");
                Console.WriteLine($"Failure to create an configuration context. authApi.Login has UserName of {Credentials[id].UserName} and Password of {Credentials[id].Password}");
                throw new NullReferenceException(nameof(configuration));
            }
            else
            {


                Console.WriteLine("Reading Accounts...");
            }

            SalesOrderApi salesOrderApi = new(configuration);
            BusinessAccountApi businessAccountApi = new(configuration);

            if (salesOrderApi is null)
            {
                _logger.LogError($"Failure to create an salesOrderApi using {configuration.ToString}");
                Console.WriteLine($"Failure to create an salesOrderApi using {configuration.ToString}");
                throw new NullReferenceException(nameof(salesOrderApi));
            }
            else
            {
                if (businessAccountApi is null)
                {
                    _logger.LogError($"Failure to create an businessAccountApi using {configuration.ToString}");
                    Console.WriteLine($"Failure to create an businessAccountApi using {configuration.ToString}");
                    throw new NullReferenceException(nameof(businessAccountApi));
                }
                else
                {
                    if (!_context.CustomSalesOrders.Any())
                    {
                        //for 2022R1 latest salesorders are dated 2022-02-03
                        //var dateTimeOffset = new DateTime(2022, 2, 1, 0, 0, 0).ToString("s");
                        var dateTimeOffset = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 2, 1, 0, 0, 0).ToString("s");
                        string filter = @$"Date gt datetimeoffset'{dateTimeOffset}'";
                        string select = "OrderType,OrderNbr,Status,Date,Shipments/ShipmentDate,CustomerID,OrderedQty,OrderTotal,CurrencyID, LastModified";
                        string expand = "Shipments";
                        string custom = String.Empty;
                        int skip = 0;
                        int? top = 10;

                        SalesOrders = salesOrderApi.GetList(select, filter, expand, custom, skip, top);

                        List<CustomSalesOrderInfo> c_temps = new();

                        for (int idx = 0; idx < (SalesOrders.Count - 1); idx++)
                        {
                            DateTimeValue shipmentDate = DateTime.Parse("1900-01-01T00:00:01.000");
                            if (SalesOrders[idx].Shipments.Count > 0) shipmentDate = SalesOrders[idx].Shipments[0].ShipmentDate;
                            string[] customerID = { SalesOrders[idx].CustomerID.Value };
                            BusinessAccount = businessAccountApi.GetByKeys(customerID);
                            CustomSalesOrderInfo customSalesOrderInfo = new(SalesOrders[idx], shipmentDate, this.BusinessAccount.Name);
                            ConvertToCustomSalesOrder co_temp = new ConvertToCustomSalesOrder(customSalesOrderInfo);
                            c_temps.Add(customSalesOrderInfo);
                            _context.CustomSalesOrders.Add(co_temp);

                        }
                        this.CustomSalesOrderInfo = c_temps;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {


                        List<CustomSalesOrderInfo> c_temps = new();
                        List<CustomSalesOrder> co_temps = new();
                        co_temps = await _context.CustomSalesOrders.ToListAsync();
                        foreach (var co in co_temps)
                        {
                            ConvertToCustomSalesOrderInfo c_temp = new(co);
                            c_temps.Add(c_temp);

                        }
                        this.CustomSalesOrderInfo = c_temps;

                    }

                }

            }
        }
        catch (Exception e)
        {

            _logger.LogError($"Exception caught {e.Message}");
            Console.WriteLine($"Exception caught {e.Message}");
        }
        finally
        {
            //we use logout in finally block because we need to always logut, even if the request failed for some reason
            if (authApi.TryLogout())
            {
                _logger.LogInformation($"Logged out Successfully");
                Console.WriteLine("Logged out successfully.");
            }
            else
            {
                _logger.LogError("Error while logging out", authApi.ExceptionFactory);
                Console.WriteLine("An error occured during logout.");
            }
        }

        if (SalesOrders is null)
        {
            _logger.LogError($"SalesOrder list is empty {SalesOrders}");
            Console.WriteLine($"SalesOrder list is empty {SalesOrders}");
            throw new NullReferenceException(nameof(SalesOrders));
        }

        return Page();
    }
    #endregion

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"From Date is {FromDate}: To Date is {ToDate}");

        List<SalesOrder_Model> c_temps = new();
        List<SalesOrder_App> co_temps = new();
        co_temps = await _context.SalesOrders_App.Where(x => x.Date >= FromDate && x.Date <= ToDate).ToListAsync();
        foreach (var co in co_temps)
        {
            ToSalesOrder_Model c_temp = new(co);
            c_temps.Add(c_temp);

        }
        this.CustomSalesOrderInfo = c_temps;

        return Page();
    }

}
#region classes

public class CustomSalesOrderInfo
{
    //ctor
    public CustomSalesOrderInfo()
    { }
    public CustomSalesOrderInfo(SalesOrder so_value, DateTimeValue sp_value, StringValue ba_value)
    {
        OrderType = so_value.OrderType;
        OrderNbr = so_value.OrderNbr;
        Status = so_value.Status;
        Date = so_value.Date;
        CustomerID = so_value.CustomerID;
        OrderedQty = so_value.OrderedQty;
        OrderTotal = so_value.OrderTotal;
        CurrencyID = so_value.CurrencyID;
        LastModified = so_value.LastModified;
        ShipmentDate = sp_value;
        CustomerName = ba_value;
    }
    //properties
    public StringValue OrderType { get; set; }
    public StringValue OrderNbr { get; set; }
    public StringValue Status { get; set; }
    public DateTimeValue Date { get; set; }
    public StringValue CustomerID { get; set; }
    public DecimalValue OrderedQty { get; set; }
    public DecimalValue OrderTotal { get; set; }
    public StringValue CurrencyID { get; set; }
    public DateTimeValue LastModified { get; set; }
    public DateTimeValue ShipmentDate { get; set; }
    public StringValue CustomerName { get; set; }
    #endregion
}
