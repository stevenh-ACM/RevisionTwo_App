using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.ShipmentDetails
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
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

            var spdetail = await _context.ShipmentDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (spdetail == null)
            {
                return NotFound();
            }
            else 
            {
                SPDetail = spdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ShipmentDetails == null)
            {
                return NotFound();
            }
            var spdetail = await _context.ShipmentDetails.FindAsync(id);

            if (spdetail != null)
            {
                SPDetail = spdetail;
                _context.ShipmentDetails.Remove(SPDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
