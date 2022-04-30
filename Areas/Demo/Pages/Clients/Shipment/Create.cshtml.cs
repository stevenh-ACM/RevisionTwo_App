#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models.App;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Shipment
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
        public Shipment_App Shipment_App { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shipment_App.Add(Shipment_App);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
