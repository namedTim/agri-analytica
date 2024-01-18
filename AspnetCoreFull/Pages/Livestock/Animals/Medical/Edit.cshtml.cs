using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals.Medical
{
    public class EditModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public EditModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnimalMedicalHistory AnimalMedicalHistory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnimalMedicalHistories == null)
            {
                return NotFound();
            }

            var animalmedicalhistory =  await _context.AnimalMedicalHistories.FirstOrDefaultAsync(m => m.Id == id);
            if (animalmedicalhistory == null)
            {
                return NotFound();
            }
            AnimalMedicalHistory = animalmedicalhistory;
           ViewData["AnimalMedicalCondtionTypeId"] = new SelectList(_context.AnimalMedicalCondtionTypes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AnimalMedicalHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalMedicalHistoryExists(AnimalMedicalHistory.Id))
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

        private bool AnimalMedicalHistoryExists(int id)
        {
          return (_context.AnimalMedicalHistories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
