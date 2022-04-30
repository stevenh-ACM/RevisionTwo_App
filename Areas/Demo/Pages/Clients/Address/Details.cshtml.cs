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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Address
{
    public class DetailsModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public DetailsModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public Address_App Address_App { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address_App = await _context.Address_App.FirstOrDefaultAsync(m => m.Id == id);

            if (Address_App == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
