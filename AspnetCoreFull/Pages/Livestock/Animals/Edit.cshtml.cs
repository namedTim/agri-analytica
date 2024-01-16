using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Data.Enums;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals
{
    public class EditModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public EditModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal =  await _context.Animals.FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            Animal = animal;
           ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "Name");
           ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
          Animal.AgriSectorId = (int)eAgriType.Zivinoreja; // You can only add animals in Livestock section therefore it's fixed
          Animal.Gender = await _context.Genders.FindAsync(Animal.GenderId);
          Animal.AnimalType = await _context.AnimalTypes.FindAsync(Animal.AnimalTypeId);
          ModelState.Clear();
          TryValidateModel(Animal);
          if (!ModelState.IsValid)
          {
            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
            {
              // Log or examine these errors
              Console.WriteLine(error.ErrorMessage);
            }

            return Page();
          }

          _context.Attach(Animal).State = EntityState.Modified;

          try
          {
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!AnimalExists(Animal.Id))
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

        private bool AnimalExists(int id)
        {
          return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
