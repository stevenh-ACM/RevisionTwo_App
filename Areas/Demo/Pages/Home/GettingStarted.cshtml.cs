#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RevisionTwo_App.Areas.Demo.Pages.Home;

public class GettingStartedModel : PageModel
{
    private readonly ILogger<GettingStartedModel> _logger;

    public GettingStartedModel(ILogger<GettingStartedModel> logger) => _logger = logger;
    public void OnGet()
    {
    }
}
