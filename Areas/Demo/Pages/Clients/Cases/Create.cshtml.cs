#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RevisionTwo_App.Data;
using RevisionTwo_App.Helper;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Cases
{
    public class CreateModel : PageModel
    {
        #region ctor
        private readonly ILogger<CreateModel> _logger;
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CRCase CRCase { get; set; } = default!;
        [BindProperty]
        public Combo_Boxes combo_Boxes { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.CRCases == null || CRCase == null)
            {
                return Page();
            }

            _context.CRCases.Add(CRCase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
