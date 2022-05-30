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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.ShipmentDetails
{
    public class EditModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public EditModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SPDetail SPDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShipmentDetails == null)
            {
                return NotFound();
            }

            var spdetail =  await _context.ShipmentDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (spdetail == null)
            {
                return NotFound();
            }
            SPDetail = spdetail;
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

            _context.Attach(SPDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPDetailExists(SPDetail.Id))
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

        private bool SPDetailExists(int id)
        {
          return (_context.ShipmentDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
