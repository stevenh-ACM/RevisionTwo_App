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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Bills
{
    public class EditModel : PageModel
    {
        #region ctor
        private readonly ILogger<EditModel> _logger;
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

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
            AR_Bill = ar_bill;
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

            _context.Attach(AR_Bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AR_BillExists(AR_Bill.Id))
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

        private bool AR_BillExists(int id)
        {
            return (_context.AR_Bills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
