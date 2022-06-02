using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.Cases
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

        public CRCase CRCase { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CRCases == null)
            {
                return NotFound();
            }

            var crcase = await _context.CRCases.FirstOrDefaultAsync(m => m.Id == id);
            if (crcase == null)
            {
                return NotFound();
            }
            else 
            {
                CRCase = crcase;
            }
            return Page();
        }
    }
}
