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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Address
{
    public class EditModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public EditModel(RevisionTwo_App.Data.AppDbContext context)
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

            var addr =  await _context.Addrs.FirstOrDefaultAsync(m => m.Id == id);
            if (addr == null)
            {
                return NotFound();
            }
            Addr = addr;
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

            _context.Attach(Addr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddrExists(Addr.Id))
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

        private bool AddrExists(int id)
        {
          return (_context.Addrs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
