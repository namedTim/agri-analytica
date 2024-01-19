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

namespace AspnetCoreFull.Pages.Livestock.Animals.ProgressType
{
    public class EditModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public EditModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnimalProgressType AnimalProgressType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnimalProgressTypes == null)
            {
                return NotFound();
            }

            var animalprogresstype =  await _context.AnimalProgressTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (animalprogresstype == null)
            {
                return NotFound();
            }
            AnimalProgressType = animalprogresstype;
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

            _context.Attach(AnimalProgressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalProgressTypeExists(AnimalProgressType.Id))
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

        private bool AnimalProgressTypeExists(int id)
        {
          return (_context.AnimalProgressTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
