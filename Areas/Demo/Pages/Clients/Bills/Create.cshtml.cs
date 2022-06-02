using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using RevisionTwo_App.Data;
using RevisionTwo_App.Helper;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Bills
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
        public AR_Bill AR_Bill { get; set; } = default!;
        [BindProperty]
        public Combo_Boxes combo_Boxes { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.AR_Bills == null || AR_Bill == null)
            {
                return Page();
            }

            _context.AR_Bills.Add(AR_Bill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
