
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RevisionTwo_App.Areas.Demo.Pages.Home;

public class AboutOldModel : PageModel
{
    private readonly ILogger<AboutOldModel> _logger;

    public AboutOldModel(ILogger<AboutOldModel> logger) => _logger = logger;
    public void OnGet()
    {
    }
}
