#nullable disable

using RevisionTwo_App.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RevisionTwo_App.Areas.Demo.Pages.Home;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }
    public void OnGet()
    { }

}