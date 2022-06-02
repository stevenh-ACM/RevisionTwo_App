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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Opportunities
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
        public OP OP { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Opportunities == null)
            {
                return NotFound();
            }

            var op =  await _context.Opportunities.FirstOrDefaultAsync(m => m.Id == id);
            if (op == null)
            {
                return NotFound();
            }
            OP = op;
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

            _context.Attach(OP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OPExists(OP.Id))
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

        private bool OPExists(int id)
        {
          return (_context.Opportunities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
