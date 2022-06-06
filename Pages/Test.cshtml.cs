using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RevisionTwo_App.Data;

namespace RevisionTwo_App.Pages;

public class TestModel : PageModel
{
    #region ctor
    private readonly ILogger<TestModel> _logger;
    private readonly AppDbContext _context;

    public TestModel(AppDbContext context, ILogger<TestModel> logger)
    {
        _context = context;
        _logger = logger;
    }
    #endregion
    public void OnGet()
    {
    }
}
