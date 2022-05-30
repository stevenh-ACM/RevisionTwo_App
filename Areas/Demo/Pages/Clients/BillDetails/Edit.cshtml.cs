using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.BillDetails
{
    public class EditModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public EditModel(RevisionTwo_App.Data.AppDbContext context)
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

            var ar_billdetail =  await _context.AR_BillDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (ar_billdetail == null)
            {
                return NotFound();
            }
            AR_BillDetail = ar_billdetail;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AR_BillDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AR_BillDetailExists(AR_BillDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AR_BillDetailExists(int id)
        {
          return (_context.AR_BillDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
