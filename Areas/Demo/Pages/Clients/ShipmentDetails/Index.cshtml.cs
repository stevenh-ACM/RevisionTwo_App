using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.ShipmentDetails
{
    public class IndexModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public IndexModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<SPDetail> SPDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ShipmentDetails != null)
            {
                SPDetail = await _context.ShipmentDetails.ToListAsync();
            }
        }
    }
}
