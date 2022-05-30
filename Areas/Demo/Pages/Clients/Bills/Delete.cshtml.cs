using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Bills
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AR_Bill AR_Bill { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AR_Bills == null)
            {
                return NotFound();
            }

            var ar_bill = await _context.AR_Bills.FirstOrDefaultAsync(m => m.Id == id);

            if (ar_bill == null)
            {
                return NotFound();
            }
            else 
            {
                AR_Bill = ar_bill;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AR_Bills == null)
            {
                return NotFound();
            }
            var ar_bill = await _context.AR_Bills.FindAsync(id);

            if (ar_bill != null)
            {
                AR_Bill = ar_bill;
                _context.AR_Bills.Remove(AR_Bill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
