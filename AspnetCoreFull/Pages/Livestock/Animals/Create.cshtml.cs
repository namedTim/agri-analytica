using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreFull.Pages.Livestock.Animals
{
    public class CreateModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(AspnetCoreFull.Data.AnalyticaContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
          var userId = _userManager.GetUserId(User);
          ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "Name");
          ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
          ViewData["AgriSectorId"] = new SelectList(_context.AgriSectorTypes
            .Where(x => x.AspUserId == userId), "Id", "Name");
          var parentMaleOptions = await _context.Animals
            .Where(animal => animal.GenderId == 1) // Filter for male animals
            .Join(_context.AgriSectorTypes,
              animal => animal.AgriSectorId,
              sector => sector.Id,
              (animal, sector) => new { Animal = animal, Sector = sector })
            .Where(joinedItem => joinedItem.Sector.AspUserId == userId)
            .Select(joinedItem => new
            {
              Id = joinedItem.Animal.Id,
              EarTag = joinedItem.Animal.EarTag
            })
            .ToListAsync();

          var parentFemaleOptions = await _context.Animals
            .Where(animal => animal.GenderId == 2) // Filter for male animals
            .Join(_context.AgriSectorTypes,
              animal => animal.AgriSectorId,
              sector => sector.Id,
              (animal, sector) => new { Animal = animal, Sector = sector })
            .Where(joinedItem => joinedItem.Sector.AspUserId == userId)
            .Select(joinedItem => new
            {
              Id = joinedItem.Animal.Id,
              EarTag = joinedItem.Animal.EarTag
            })
            .ToListAsync();

          var noParentOption = new { Id = 0, EarTag = "NaN" };
          parentMaleOptions.Insert(0, noParentOption);
          parentFemaleOptions.Insert(0, noParentOption);

          ViewData["ParentMaleId"] = new SelectList(parentMaleOptions, "Id", "EarTag");
          ViewData["ParentFemaleId"] = new SelectList(parentFemaleOptions, "Id", "EarTag");

          return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          Animal.Gender = await _context.Genders.FindAsync(Animal.GenderId);
          Animal.AnimalType = await _context.AnimalTypes.FindAsync(Animal.AnimalTypeId);
          ModelState.Clear();
          TryValidateModel(Animal);
          if (!ModelState.IsValid || _context.Animals == null || Animal == null)
          {
            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
            {
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
