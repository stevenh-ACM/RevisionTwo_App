using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.BillDetails
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
        public AR_BillDetail AR_BillDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AR_BillDetails == null || AR_BillDetail == null)
            {
                return Page();
            }

            _context.AR_BillDetails.Add(AR_BillDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
