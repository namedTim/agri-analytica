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
    public class DetailsModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public DetailsModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

      public AnimalProgressType AnimalProgressType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnimalProgressTypes == null)
            {
                return NotFound();
            }

            var animalprogresstype = await _context.AnimalProgressTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (animalprogresstype == null)
            {
                return NotFound();
            }
            else 
            {
                AnimalProgressType = animalprogresstype;
            }
            return Page();
        }
    }
}
