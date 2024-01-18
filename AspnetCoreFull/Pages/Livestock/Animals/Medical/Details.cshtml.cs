using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals.Medical
{
    public class DetailsModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public DetailsModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

      public AnimalMedicalHistory AnimalMedicalHistory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnimalMedicalHistories == null)
            {
                return NotFound();
            }

            var animalmedicalhistory = await _context.AnimalMedicalHistories.FirstOrDefaultAsync(m => m.Id == id);
            if (animalmedicalhistory == null)
            {
                return NotFound();
            }
            else 
            {
                AnimalMedicalHistory = animalmedicalhistory;
            }
            return Page();
        }
    }
}
