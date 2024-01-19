using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals.ProgressType
{
    public class IndexModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public IndexModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        public IList<AnimalProgressType> AnimalProgressType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AnimalProgressTypes != null)
            {
                AnimalProgressType = await _context.AnimalProgressTypes.ToListAsync();
            }
        }
    }
}
