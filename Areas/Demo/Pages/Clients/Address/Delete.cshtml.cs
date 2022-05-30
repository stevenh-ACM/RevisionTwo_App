using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Address
{
    public class DeleteModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DeleteModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Addr Addr { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Addrs == null)
            {
                return NotFound();
            }

            var addr = await _context.Addrs.FirstOrDefaultAsync(m => m.Id == id);

            if (addr == null)
            {
                return NotFound();
            }
            else 
            {
                Addr = addr;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Addrs == null)
            {
                return NotFound();
            }
            var addr = await _context.Addrs.FindAsync(id);

            if (addr != null)
            {
                Addr = addr;
                _context.Addrs.Remove(Addr);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
