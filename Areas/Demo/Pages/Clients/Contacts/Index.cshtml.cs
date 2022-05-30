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
using System;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Contacts;

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
    public List<Contact> Contacts { get; set; }
    public BusinessAccount BAccount { get; set; }
    public List<CO> co_cached { get; set; }
    private int id { get; set; }

    /// <summary>
    /// Search fields
    /// </summary>
    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FromDate { get; set; }

    [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ToDate { get; set; } = DateTime.Now;

    [BindProperty]
    public List<CO> CO { get; set; }


    #endregion

    #region methods
    /// <summary>
    /// Retrieve list of the most recent 10 SalesOrders
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        Credentials = await _context.Credentials.ToListAsync();

        co_cached = await _context.Contacts.ToListAsync();

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

        if (!co_cached.Any())
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


                ContactApi contactApi = new(configuration);
                if (contactApi is null)
                {
                    _logger.LogError($"Failure to create an contactApi using {configuration.ToString}");
                    throw new NullReferenceException(nameof(contactApi));
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
                        string select = "Active, ContactID, DisplayName, BusinessAccount, JobTitle, Owner, CompanyName, ContactClass,  Email, Phone1, LastModifiedDateTime";
                        string expand = "";
                        string custom = String.Empty;
                        int skip = 0;
                        int? top = 15;

                        Contacts = contactApi.GetList(select, filter, expand, custom, skip, top);

                        DateTimeValue defaultDate = DateTime.Parse("1900-01-01T00:00:01.000");

                        for (int idx = 0; idx < (Contacts.Count - 1); idx++)
                        {
                            var _co = new ConvertToCO(Contacts[idx]);

                            _context.Contacts.Add(_co);
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

        CO = co_cached;

        if (CO is null)
        {
            _logger.LogError($"Contact list is empty {CO}");
            throw new NullReferenceException(nameof(CO));
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {

        CO = await _context.Contacts.ToListAsync();

        return Page();
    }
    #endregion
}

