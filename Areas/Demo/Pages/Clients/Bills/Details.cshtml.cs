using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Bills
{
    public class DetailsModel : PageModel
    {
        #region ctor
        private readonly ILogger<DetailsModel> _logger;
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        public AR_Bill AR_Bill { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AR_Bills == null)
            {
                return NotFound();
            }

            var ar_bill = await _context.AR_Bills.FirstOrDefaultAsync(m => m.Id == id);
            if (ar_bill == null)
            {
                return NotFound();
            }
            else 
            {
                AR_Bill = ar_bill;
            }
            return Page();
        }
    }
}
