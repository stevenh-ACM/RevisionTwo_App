using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Opportunities
{
    public class DetailsModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DetailsModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

      public OP OP { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Opportunities == null)
            {
                return NotFound();
            }

            var op = await _context.Opportunities.FirstOrDefaultAsync(m => m.Id == id);
            if (op == null)
            {
                return NotFound();
            }
            else 
            {
                OP = op;
            }
            return Page();
        }
    }
}
