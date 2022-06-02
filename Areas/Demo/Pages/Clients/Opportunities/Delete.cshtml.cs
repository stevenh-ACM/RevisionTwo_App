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
    public class DeleteModel : PageModel
    {
        #region ctor
        private readonly ILogger<DeleteModel> _logger;
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Opportunities == null)
            {
                return NotFound();
            }
            var op = await _context.Opportunities.FindAsync(id);

            if (op != null)
            {
                OP = op;
                _context.Opportunities.Remove(OP);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
