using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals.ProgressType
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
            return Page();
        }

        [BindProperty]
        public AnimalProgressType AnimalProgressType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AnimalProgressTypes == null || AnimalProgressType == null)
            {
                return Page();
            }

            _context.AnimalProgressTypes.Add(AnimalProgressType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
