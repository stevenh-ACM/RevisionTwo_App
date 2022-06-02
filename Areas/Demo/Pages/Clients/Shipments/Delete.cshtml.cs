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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shipments == null)
            {
                return NotFound();
            }
            var sp = await _context.Shipments.FindAsync(id);

            if (sp != null)
            {
                SP = sp;
                _context.Shipments.Remove(SP);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
