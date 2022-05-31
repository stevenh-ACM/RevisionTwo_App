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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Opportunities;

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
    public List<Opportunity> Opportunities { get; set; }
    public List<OP> op_cached { get; set; }
    private int id { get; set; }

    /// <summary>
    /// Search fields
    /// </summary>
    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FromDate { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ToDate { get; set; } = DateTime.Now;

    [BindProperty]
    public List<OP> OP { get; set; }

    #endregion

    #region methods
    /// <summary>
    /// Retrieve list of the most recent 10 SalesOrders
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        Credentials = await _context.Credentials.ToListAsync();

        op_cached = await _context.Opportunities.ToListAsync();

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

        if (!op_cached.Any())
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
                    Console.WriteLine("Reading Opportunitities...");
                }


                OpportunityApi opportunityApi = new(configuration);
                if (opportunityApi is null)
                {
                    _logger.LogError($"Failure to create a caseApi using {configuration.ToString}");
                    throw new NullReferenceException(nameof(opportunityApi));
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

                        var dateTimeOffset = new DateTime(DateTime.Now.Year - 2, /*DateTime.Now.Month*/1, 1, 0, 0, 0).ToString("s");
                        string filter = @$"lastmodifieddatetime gt datetimeoffset'{dateTimeOffset}'";
                        string select = "OpportunityID,Subject,Status,Stage,CurrencyID,Total,ClassID,Owner,ContactDisplayName,BusinessAccount,LastModifiedDateTime";
                        string expand = "";
                        string custom = String.Empty;
                        int skip = 0;
                        int? top = 15;

                        Opportunities = opportunityApi.GetList(select, filter, expand, custom, skip, top);

                        for (int idx = 0; idx < (Opportunities.Count - 1); idx++)
                        {
                            OP _op = new ConvertToOP(Opportunities[idx]);
                            op_cached.Add(_op);
                            _context.Opportunities.Add(_op);
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

        OP = op_cached;

        if (OP is null)
        {
            _logger.LogError($"SalesOrder list is empty {OP}");
            throw new NullReferenceException(nameof(OP));
        }

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"From Date is {FromDate}: To Date is {ToDate}");

        OP = await _context.Opportunities.Where(x => x.LastModifiedDateTime >= FromDate && x.LastModifiedDateTime <= ToDate).ToListAsync();

        return Page();
    }
}
#endregion
