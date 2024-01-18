using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreFull.Data;
using AspnetCoreFull.Data.Services;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreFull.Pages.Livestock.Animals.Progress
{
    public class CreateModel : PageModel
    {
        private readonly AnimalService _animalService;
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public CreateModel(AspnetCoreFull.Data.AnalyticaContext context, AnimalService animalService, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _animalService = animalService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? animalId)
        {
          ViewData["AnimalProgressTypeId"] = new SelectList(
            await _context.AnimalProgressTypes
              .Select(ap => new
              {
                Id = ap.Id,
                Description = ap.Name + " | " + ap.Description
              }).ToListAsync(),
            "Id",
            "Description");

          var user = await _userManager.GetUserAsync(User);
          var animals = await _animalService.GetAnimalsForUser(user.Id);

          if (Id.HasValue)
          {
            animals = animals.Where(a => a.Id == 1).ToList();
          }

          ViewData["Animals"] = new SelectList(animals, "Id", "EarTag", ViewData["SelectedAnimalId"]);

          return Page();
        }

        [BindProperty]
        public AnimalProgress AnimalProgress { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          var animal = _context.Animals.First(a => a.Id == AnimalProgress.AnimalId);
          AnimalProgress.AnimalAnimalTypeId = animal.AnimalTypeId;

          if (!ModelState.IsValid || _context.AnimalProgresses == null || AnimalProgress == null)
            {
              foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
              {
                Console.WriteLine(error.ErrorMessage);
              }
            }

            _context.AnimalProgresses.Add(AnimalProgress);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
