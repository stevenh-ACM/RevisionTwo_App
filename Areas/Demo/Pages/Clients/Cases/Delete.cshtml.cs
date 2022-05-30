using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Cases
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CRCase CRCase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CRCases == null)
            {
                return NotFound();
            }

            var crcase = await _context.CRCases.FirstOrDefaultAsync(m => m.Id == id);

            if (crcase == null)
            {
                return NotFound();
            }
            else 
            {
                CRCase = crcase;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CRCases == null)
            {
                return NotFound();
            }
            var crcase = await _context.CRCases.FindAsync(id);

            if (crcase != null)
            {
                CRCase = crcase;
                _context.CRCases.Remove(CRCase);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
