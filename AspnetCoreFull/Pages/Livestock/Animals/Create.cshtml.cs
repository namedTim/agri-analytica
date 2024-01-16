using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreFull.Data;
using AspnetCoreFull.Data.Enums;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals
{
    public class CreateModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public CreateModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "Name");
        ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          Animal.AgriSectorId = (int)eAgriType.Zivinoreja; // You can only add animals in Livestock section therefore it's fixed
          Animal.Gender = await _context.Genders.FindAsync(Animal.GenderId);
          Animal.AnimalType = await _context.AnimalTypes.FindAsync(Animal.AnimalTypeId);
          ModelState.Clear();
          TryValidateModel(Animal);
          if (!ModelState.IsValid || _context.Animals == null || Animal == null)
          {
            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
            {
              // Log or examine these errors
              Console.WriteLine(error.ErrorMessage);
            }

            return Page();
          }

          _context.Animals.Add(Animal);
          await _context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}
