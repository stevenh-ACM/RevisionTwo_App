#nullable disable

using RevisionTwo_App.Auxillary;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

using Acumatica.Auth.Api;
using Acumatica.Default_20_200_001.Api;
using Acumatica.Default_20_200_001.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Task = System.Threading.Tasks.Task;

namespace RevisionTwo_App.Areas.Demo.Pages.SalesOrders;

public class DetailsModel : PageModel
{

    private readonly AppDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public DetailsModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Credentials list of credentials in db
    /// </summary>
    public List<Credential> Credentials { get; set; }

    /// <summary>
    /// Salesorder list retrieved from API"
    /// </summary>
    [BindProperty]
    public SalesOrder SalesOrder { get; set; }
    [BindProperty]
    public List<SalesOrderDetail> SalesOrderDetails { get; set; }
    [BindProperty]
    public List<SalesOrderShipment> SalesOrderShipments { get; set; }
    [BindProperty]
    public List<SalesOrdersDiscountDetails> DiscountDetails { get; set; }
    [BindProperty]
    public List<SalesOrderPayment> Payments { get; set; }
    [BindProperty]
    public List<TaxDetail> TaxDetails { get; set; }

    public async Task<IActionResult> OnGetAsync(string orderNbr, string orderType)
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
            };

            SalesOrderApi salesOrderApi = new SalesOrderApi(configuration);
            if (salesOrderApi is null)
            {
                _logger.LogError($"Failure to create an salesOrderApi using {configuration.ToString}");
                Console.WriteLine($"Failure to create an salesOrderApi using {configuration.ToString}");
                throw new NullReferenceException(nameof(salesOrderApi));
            }
            else
            {
                Console.WriteLine("Reading Sales Order by Keys...");
            }

            SalesOrder = salesOrderApi.GetByKeys(new List<string>() { orderType, orderNbr });

            //Get SalesOrder Lists
            SalesOrderDetails = SalesOrder.Details;
            SalesOrderShipments = SalesOrder.Shipments;
            if (SalesOrderDetails is not null)
            {
                for (int i = 0; i < SalesOrder.Details.Count; i++)
                {
                    SalesOrderDetails[i] = SalesOrder.Details[i];
                }
            }
            if (SalesOrderShipments is not null)
            {
                for (int i = 0; i < SalesOrder.Shipments.Count; i++)
                {
                    SalesOrderShipments[i] = SalesOrder.Shipments[i];
                }
            }
            //DiscountDetails = SalesOrder.DiscountDetails;
            //Payments = SalesOrder.Payments;
            //TaxDetails = SalesOrder.TaxDetails;


            Console.WriteLine("Order Total: " + SalesOrder.OrderTotal.Value);
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

        if (SalesOrder is not null)
        {
                Console.WriteLine("SalesOrder Nbr: " + SalesOrder.OrderNbr.Value + ";");
        }
        else
        {
            _logger.LogError($"SalesOrder list is empty {SalesOrder}");
            Console.WriteLine($"SalesOrder list is empty {SalesOrder}");
            throw new NullReferenceException(nameof(SalesOrder));
        }

        return Page();
    }
}
