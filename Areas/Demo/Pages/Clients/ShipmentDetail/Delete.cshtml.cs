#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models.App;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.ShipmentDetail
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShipmentDetail_App ShipmentDetail_App { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShipmentDetail_App = await _context.ShipmentDetail_App.FirstOrDefaultAsync(m => m.Id == id);

            if (ShipmentDetail_App == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShipmentDetail_App = await _context.ShipmentDetail_App.FindAsync(id);

            if (ShipmentDetail_App != null)
            {
                _context.ShipmentDetail_App.Remove(ShipmentDetail_App);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
