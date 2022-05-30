using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Cases
{
    public class CreateModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public CreateModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CRCase CRCase { get; set; } = default!;
        

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
