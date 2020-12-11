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
    public class IndexModel : PageModel
    {
        private readonly Testdatabase_10_12_2020.Data.ApplicationDbContext _context;

        public IndexModel(Testdatabase_10_12_2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Modules> Modules { get;set; }

        public async Task OnGetAsync()
        {
            Modules = await _context.Modules.ToListAsync();
        }
    }
}
