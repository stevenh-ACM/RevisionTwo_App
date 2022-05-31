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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Bills;

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
    public List<Bill> Bills { get; set; }
    public BusinessAccount BAccount { get; set; }
    public List<AR_Bill> ar_cached { get; set; }
    private int id { get; set; }

    /// <summary>
    /// Search fields
    /// </summary>
    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FromDate { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ToDate { get; set; } = DateTime.Now;

    [BindProperty]
    public List<AR_Bill> AR_Bill { get; set; }

    #endregion

    #region methods
    /// <summary>
    /// Retrieve list of the most recent 10 Bills
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        Credentials = await _context.Credentials.ToListAsync();

        ar_cached = await _context.AR_Bills.ToListAsync();

        if (Credentials is null)
        {
            _logger.LogError($"No Credentials exist. Please create at least one Credential!");
            return RedirectToPage("Pages/Home/Index");
        }
        else
        {
            var id = new AuthId().getAuthId(Credentials);
            _logger.LogError($"Credential secured. SiteURL is {Credentials[id].SiteUrl} and id is {id}");
        }

        if (!ar_cached.Any())
        {
            AuthApi authApi = new AuthApi(Credentials[id].SiteUrl,
                requestInterceptor: RequestLogger.LogRequest, responseInterceptor: RequestLogger.LogResponse);

            if (authApi is null)
            {
                _logger.LogError($"Failure to create an authAPI context. SiteURL is {Credentials[id].SiteUrl} and id is {id}");
                throw new NullReferenceException(nameof(authApi));
            }

            try
            {
                Configuration configuration = authApi.LogIn(Credentials[id].UserName, Credentials[id].Password, "", "", "");

                if (configuration is null)
                {
                    _logger.LogError($"Failure to create an configuration context. authApi.Login has UserName of {Credentials[id].UserName} and Password of {Credentials[id].Password}");
                    throw new NullReferenceException(nameof(configuration));
                }
                else
                {
                    Console.WriteLine("Reading Bills...");
                }


                BillApi billApi = new(configuration);
                if (billApi is null)
                {
                    _logger.LogError($"Failure to create an salesOrderApi using {configuration.ToString}");
                    throw new NullReferenceException(nameof(billApi));
                }
                else
                {
                    BusinessAccountApi businessAccountApi = new(configuration);
                    if (businessAccountApi is null)
                    {
                        _logger.LogError($"Failure to create an businessAccountApi using {configuration.ToString}");
                        throw new NullReferenceException(nameof(businessAccountApi));
                    }
                    else
                    {

                        var dateTimeOffset = new DateTime(DateTime.Now.Year - 1, /*DateTime.Now.Month*/1, 1, 0, 0, 0).ToString("s");
                        string filter = @$"Date gt datetimeoffset'{dateTimeOffset}'";
                        string select = "Type, ReferenceNbr, Status, Date, PostPeriod, Vendor, Description, VendorRef, Amount, CurrencyID, LastModifiedDateTime";
                        string expand = "";
                        string custom = String.Empty;
                        int skip = 0;
                        int? top = 15;

                        Bills = billApi.GetList(select, filter, expand, custom, skip, top);

                        DateTimeValue defaultDate = DateTime.Parse("1900-01-01T00:00:01.000");

                        for (int idx = 0; idx < (Bills.Count - 1); idx++)
                        {

                            var AR_Bill = new ConvertToAR_Bill(Bills[idx]);

                            _context.AR_Bills.Add(AR_Bill);

                        }
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception caught {e.Message}");
            }
            finally
            {
                //we use logout in finally block because we need to always logut, even if the request failed for some reason
                if (authApi.TryLogout())
                {
                    _logger.LogInformation($"Logged out Successfully");
                }
                else
                {
                    _logger.LogError("Error while logging out", authApi.ExceptionFactory);
                }
            }
        }

        AR_Bill = ar_cached;

        if (AR_Bill is null)
        {
            _logger.LogError($"SalesOrder list is empty {AR_Bill}");
            throw new NullReferenceException(nameof(AR_Bill));
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"From Date is {FromDate}: To Date is {ToDate}");

        AR_Bill = await _context.AR_Bills.Where(x => x.Date >= FromDate && x.Date <= ToDate).ToListAsync();

        return Page();
    }
    #endregion
}
