using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testdatabase_10_12_2020.Data;
using Testdatabase_10_12_2020.Models;

namespace Testdatabase_10_12_2020.Pages.Module
{
    public class EditModel : PageModel
    {
        private readonly Testdatabase_10_12_2020.Data.ApplicationDbContext _context;

        public EditModel(Testdatabase_10_12_2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Modules Modules { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modules = await _context.Modules.FirstOrDefaultAsync(m => m.ID == id);

            if (Modules == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Modules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulesExists(Modules.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ModulesExists(int id)
        {
            return _context.Modules.Any(e => e.ID == id);
        }
    }
}
