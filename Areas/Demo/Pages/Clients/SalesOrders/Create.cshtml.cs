﻿#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RevisionTwo_App.Data;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Areas.Demo.Pages.Clients.SalesOrders;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public SO so { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.SalesOrders.Add(so);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
