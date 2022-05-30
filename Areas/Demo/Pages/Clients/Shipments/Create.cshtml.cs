using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Shipments
{
    public class CreateModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public CreateModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SP SP { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Shipments == null || SP == null)
            {
                return Page();
            }

            _context.Shipments.Add(SP);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
