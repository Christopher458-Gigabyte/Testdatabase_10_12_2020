using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Testdatabase_10_12_2020.Data;
using Testdatabase_10_12_2020.Models;

namespace Testdatabase_10_12_2020.Pages.Module
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Testdatabase_10_12_2020.Data.ApplicationDbContext _context;

        public CreateModel(Testdatabase_10_12_2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Modules Modules { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Modules.Add(Modules);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
