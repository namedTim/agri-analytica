using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals.Progress
{
    public class DeleteModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;

        public DeleteModel(AspnetCoreFull.Data.AnalyticaContext context)
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

            var animalprogress = await _context.AnimalProgresses.FirstOrDefaultAsync(m => m.Id == id);

            if (animalprogress == null)
            {
                return NotFound();
            }
            else 
            {
                AnimalProgress = animalprogress;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AnimalProgresses == null)
            {
                return NotFound();
            }
            var animalprogress = await _context.AnimalProgresses.FindAsync(id);

            if (animalprogress != null)
            {
                AnimalProgress = animalprogress;
                _context.AnimalProgresses.Remove(AnimalProgress);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
