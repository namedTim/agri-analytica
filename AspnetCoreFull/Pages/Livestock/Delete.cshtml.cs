using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock
{
    public class DeleteModel : PageModel
    {
        private readonly AspnetCoreFull.Data.SchoolContext _context;

        public DeleteModel(AspnetCoreFull.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AgriSectorType AgriSectorType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AgriSectorType == null)
            {
                return NotFound();
            }

            var agrisectortype = await _context.AgriSectorType.FirstOrDefaultAsync(m => m.Id == id);

            if (agrisectortype == null)
            {
                return NotFound();
            }
            else 
            {
                AgriSectorType = agrisectortype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AgriSectorType == null)
            {
                return NotFound();
            }
            var agrisectortype = await _context.AgriSectorType.FindAsync(id);

            if (agrisectortype != null)
            {
                AgriSectorType = agrisectortype;
                _context.AgriSectorType.Remove(AgriSectorType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
