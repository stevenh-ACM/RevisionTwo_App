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

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.BillDetail
{
    public class IndexModel : PageModel
    {
        private readonly RevisionTwo_App.Data.AppDbContext _context;

        public IndexModel(RevisionTwo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<BillDetail_App> BillDetail_App { get;set; }

        public async Task OnGetAsync()
        {
            BillDetail_App = await _context.BillDetail_App.ToListAsync();
        }
    }
}
