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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.SalesOrder
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOrder_App SalesOrder_App { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOrder_App = await _context.SalesOrder_App.FirstOrDefaultAsync(m => m.Id == id);

            if (SalesOrder_App == null)
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

            SalesOrder_App = await _context.SalesOrder_App.FindAsync(id);

            if (SalesOrder_App != null)
            {
                _context.SalesOrder_App.Remove(SalesOrder_App);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
