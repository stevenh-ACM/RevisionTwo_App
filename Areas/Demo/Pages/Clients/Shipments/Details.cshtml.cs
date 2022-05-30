using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Shipments
{
    public class DetailsModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DetailsModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

      public SP SP { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shipments == null)
            {
                return NotFound();
            }

            var sp = await _context.Shipments.FirstOrDefaultAsync(m => m.Id == id);
            if (sp == null)
            {
                return NotFound();
            }
            else 
            {
                SP = sp;
            }
            return Page();
        }
    }
}
