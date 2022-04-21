#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RevisionTwo_App.Areas.Demo.Pages.Home;

public class AboutModel : PageModel
{
    private readonly ILogger<AboutModel> _logger;

    public AboutModel(ILogger<AboutModel> logger) => _logger = logger;

    [BindProperty]
    public int DisplayNumOfEmployees { get; set; }

    [BindProperty]
    public double DisplayTotalRevenue { get; set; }

    [BindProperty]
    public string DisplayStartYear { get; set; }

    public void OnGet()
    {
        YearValue();
        EmpValue();
        RevValue();
    }

    public string YearValue()
    {
        Random rand = new Random();
        return DisplayStartYear = (rand.Next(2, 10) + 2008).ToString();
    }
    public int EmpValue()
    {
        Random rand = new Random();
        return DisplayNumOfEmployees = rand.Next(50, 151);
    }
    public double RevValue()
    {
        Random rand = new Random();
        return DisplayTotalRevenue = Math.Round((rand.NextDouble() * 113) + 50, 0);
    }
}

