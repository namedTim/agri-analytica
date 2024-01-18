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

namespace AspnetCoreFull.Pages.Livestock.Animals.Progress
{
    public class EditModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public EditModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnimalProgress AnimalProgress { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnimalProgresses == null)
            {
                return NotFound();
            }

            var animalprogress =  await _context.AnimalProgresses.FirstOrDefaultAsync(m => m.Id == id);
            if (animalprogress == null)
            {
                return NotFound();
            }
            AnimalProgress = animalprogress;
           ViewData["AnimalProgressTypeId"] = new SelectList(_context.AnimalProgressTypes, "Id", "Id");
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

            _context.Attach(AnimalProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalProgressExists(AnimalProgress.Id))
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

        private bool AnimalProgressExists(int id)
        {
          return (_context.AnimalProgresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
