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


namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Cases;

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
    public List<Case> Cases { get; set; }
    public List<CRCase> ca_cached { get; set; }
    private int id { get; set; }

    /// <summary>
    /// Search fields
    /// </summary>
    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FromDate { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ToDate { get; set; } = DateTime.Now;

    [BindProperty]
    public List<CRCase> CRCase { get; set; }

    #endregion

    #region methods
    /// <summary>
    /// Retrieve list of the most recent 10 SalesOrders
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        Credentials = await _context.Credentials.ToListAsync();

        ca_cached = await _context.CRCases.ToListAsync();

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

        if (!ca_cached.Any())
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
                    Console.WriteLine("Reading Accounts...");
                }


                CaseApi caseApi = new(configuration);
                if (caseApi is null)
                {
                    _logger.LogError($"Failure to create an salesOrderApi using {configuration.ToString}");
                    throw new NullReferenceException(nameof(caseApi));
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

                        var dateTimeOffset = new DateTime(DateTime.Now.Year, /*DateTime.Now.Month*/1, 1, 0, 0, 0).ToString("s");
                        string filter = "";
                        string select = "CaseID, Subject, BusinessAccount, BusinessAccountName, Status, Reason, Severity, Priority, Owner, Workgroup, ClassID, Date, LastActivityDate, LastModifiedDateTime";
                        string expand = "";
                        string custom = String.Empty;
                        int skip = 0;
                        int? top = 15;

                        Cases = caseApi.GetList(select, filter, expand, custom, skip, top);

                        DateTimeValue defaultDate = DateTime.Parse("1900-01-01T00:00:01.000");

                        for (int idx = 0; idx < (Cases.Count - 1); idx++)
                        {

                            var _so = new ConvertToCRCase(Cases[idx]);

                            _context.CRCases.Add(_so);

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

        CRCase = ca_cached;

        if (CRCase is null)
        {
            _logger.LogError($"SalesOrder list is empty {CRCase}");
            throw new NullReferenceException(nameof(CRCase));
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"From Date is {FromDate}: To Date is {ToDate}");

        CRCase = await _context.CRCases.Where(x => x.DateReported >= FromDate && x.DateReported <= ToDate).ToListAsync();

        return Page();
    }
    #endregion
}