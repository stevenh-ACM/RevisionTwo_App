using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Contacts
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
      public CO CO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var co = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);

            if (co == null)
            {
                return NotFound();
            }
            else 
            {
                CO = co;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }
            var co = await _context.Contacts.FindAsync(id);

            if (co != null)
            {
                CO = co;
                _context.Contacts.Remove(CO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
