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

namespace RevisionTwo_App.Areas.Demo.Pages.SalesOrders;

public class CreateModel : PageModel
{

    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context) => _context = context;
    public List<Credential> Credentials { get; set; }

    [BindProperty]
    public SalesOrder SalesOrder { get; set; }
    public List<SalesOrder> SalesOrders { get; set; }

    public async Task<IActionResult> OnGetAsync(string orderNbr)
    {
        Credentials = await _context.Credentials.ToListAsync();

        int id = new AuthId().getAuthId(Credentials);

        AuthApi? authApi = new AuthApi(Credentials[id].SiteUrl,
            requestInterceptor: RequestLogger.LogRequest, responseInterceptor: RequestLogger.LogResponse);



        if (orderNbr == null)
        {
            return NotFound();
        }

        try
        {
            Acumatica.RESTClient.Client.Configuration? configuration = authApi.LogIn(Credentials[id].UserName, Credentials[id].Password, "", "", "");

            Console.WriteLine("Reading Accounts...");

            SalesOrderApi? salesOrderApi = new SalesOrderApi(configuration);

            Console.WriteLine("Reading Sales Order by Keys...");

            SalesOrder = salesOrderApi.GetByKeys(new List<string>() { "SO", orderNbr });

            Console.WriteLine("Order Total: " + SalesOrder.OrderTotal.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            //we use logout in finally block because we need to always logut, even if the request failed for some reason
            if (authApi.TryLogout())
            {
                Console.WriteLine("Logged out successfully.");
            }
            else
            {
                Console.WriteLine("An error occured during logout.");
            }
        }

        Console.WriteLine("SalesOrder Nbr: " + SalesOrder.OrderNbr.Value + ";");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string orderNbr)
    {
        if (orderNbr == null)
        {
            return NotFound();
        }

        //SalesOrder = await _context.SalesOrders.FindAsync(id);

        if (SalesOrder != null)
        {
            //_context.SalesOrders.Remove(SalesOrder);
            //await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }

}