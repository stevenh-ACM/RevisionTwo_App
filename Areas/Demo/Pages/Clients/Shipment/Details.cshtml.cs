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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Shipment
{
    public class DetailsModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DetailsModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public Shipment_App Shipment_App { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shipment_App = await _context.Shipment_App.FirstOrDefaultAsync(m => m.Id == id);

            if (Shipment_App == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
