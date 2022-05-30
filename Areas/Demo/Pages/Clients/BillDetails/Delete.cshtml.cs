using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.BillDetails
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AR_BillDetail AR_BillDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AR_BillDetails == null)
            {
                return NotFound();
            }

            var ar_billdetail = await _context.AR_BillDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (ar_billdetail == null)
            {
                return NotFound();
            }
            else 
            {
                AR_BillDetail = ar_billdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AR_BillDetails == null)
            {
                return NotFound();
            }
            var ar_billdetail = await _context.AR_BillDetails.FindAsync(id);

            if (ar_billdetail != null)
            {
                AR_BillDetail = ar_billdetail;
                _context.AR_BillDetails.Remove(AR_BillDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
