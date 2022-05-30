using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.BillDetails
{
    public class IndexModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public IndexModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<AR_BillDetail> AR_BillDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AR_BillDetails != null)
            {
                AR_BillDetail = await _context.AR_BillDetails.ToListAsync();
            }
        }
    }
}
