using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testdatabase_10_12_2020.Data;
using Testdatabase_10_12_2020.Models;

namespace Testdatabase_10_12_2020.Pages.Module
{
    public class DetailsModel : PageModel
    {
        private readonly Testdatabase_10_12_2020.Data.ApplicationDbContext _context;

        public DetailsModel(Testdatabase_10_12_2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
