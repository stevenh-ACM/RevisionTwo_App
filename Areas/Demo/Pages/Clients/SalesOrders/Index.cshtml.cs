#nullable disable

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Acumatica.Auth.Api;
using Acumatica.Default_20_200_001.Api;
using Acumatica.Default_20_200_001.Model;
using Acumatica.RESTClient.Model;
using Acumatica.RESTClient.Client;

using RevisionTwo_App.Auxillary;
using RevisionTwo_App.Data;
using RevisionTwo_App.DTOs;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.SalesOrders;

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

    #region Properties
    /// <summary>
    /// Credentials list of credentials in db
    /// </summary>
    public List<Credential> Credentials { get; set; }
    public List<SalesOrder> SalesOrders { get; set; }
    public List<SO> so_cached { get; set; } = new();
    public BusinessAccount BAccount { get; set; }
    private int id { get; set; }

    /// <summary>
    /// Search fields
    /// </summary>
    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FromDate { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ToDate { get; set; } = DateTime.Now;

    [BindProperty]
    public List<SO> so { get; set; }


    #endregion

    #region methods
    /// <summary>
    /// Retrieve list of the most recent 10 SalesOrders
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        Credentials = await _context.Credentials.ToListAsync();

        if (Credentials is null)
        {
            _logger.LogError($"No Credentials exist. Please create at least one Credential!");
            Console.WriteLine($"No Credentials exist. Please create at least one Credential!");
            return RedirectToPage("Pages/Home/Index");
        }
        else
        {
            var id = new AuthId().getAuthId(Credentials);
            _logger.LogError($"Credential secured. SiteURL is {Credentials[id].SiteUrl} and id is {id}");
            Console.WriteLine($"Credential secured. SiteURL is {Credentials[id].SiteUrl} and id is {id}");
        }

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
            Configuration configuration = authApi.LogIn(Credentials[id].UserName, Credentials[id].Password, "", "", "");

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
            if (salesOrderApi is null)
            {
                _logger.LogError($"Failure to create an salesOrderApi using {configuration.ToString}");
                Console.WriteLine($"Failure to create an salesOrderApi using {configuration.ToString}");
                throw new NullReferenceException(nameof(salesOrderApi));
            }
            else
            {
                BusinessAccountApi businessAccountApi = new(configuration);
                if (businessAccountApi is null)
                {
                    _logger.LogError($"Failure to create an businessAccountApi using {configuration.ToString}");
                    Console.WriteLine($"Failure to create an businessAccountApi using {configuration.ToString}");
                    throw new NullReferenceException(nameof(businessAccountApi));
                }
                else
                {

                    var dateTimeOffset = new DateTime(DateTime.Now.Year, /*DateTime.Now.Month*/1, 1, 0, 0, 0).ToString("s");
                    string filter = @$"Date gt datetimeoffset'{dateTimeOffset}'";
                    string select = "OrderType,OrderNbr,Status,Date,Shipments/ShipmentDate,CustomerID,OrderedQty,OrderTotal,CurrencyID, LastModified";
                    string expand = "Shipments";
                    string custom = String.Empty;
                    int skip = 0;
                    int? top = 15;

                    SalesOrders = salesOrderApi.GetList(select, filter, expand, custom, skip, top);

                    DateTimeValue defaultDate = DateTime.Parse("1900-01-01T00:00:01.000");

                    for (int idx = 0; idx < (SalesOrders.Count - 1); idx++)
                    {
                        SalesOrders[idx].Shipments[0].ShipmentDate = SalesOrders[idx].Shipments[0].ShipmentDate ?? defaultDate;
                        string[] customerID = { SalesOrders[idx].CustomerID.Value };
                        BusinessAccount baAccount = businessAccountApi.GetByKeys(customerID);

                        var _so = new ConvertToSO(SalesOrders[idx], baAccount, SalesOrders[idx].Shipments[0].ShipmentDate);

                        so_cached.Add(_so);
                        _context.SalesOrders.Add(_so);

                    }
                    this.so = so_cached;
                    await _context.SaveChangesAsync();
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

        //if (SalesOrders is null)
        //{
        //    _logger.LogError($"SalesOrder list is empty {SalesOrders}");
        //    Console.WriteLine($"SalesOrder list is empty {SalesOrders}");
        //    throw new NullReferenceException(nameof(SalesOrders));
        //}

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"From Date is {FromDate}: To Date is {ToDate}");

        so = await _context.SalesOrders.Where(x => x.Date >= FromDate && x.Date <= ToDate).ToListAsync();

        return Page();
    }
    #endregion
}

