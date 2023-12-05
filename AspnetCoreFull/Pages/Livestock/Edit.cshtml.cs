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

namespace AspnetCoreFull.Pages.Livestock
{
    public class EditModel : PageModel
    {
        private readonly AspnetCoreFull.Data.SchoolContext _context;

        public EditModel(AspnetCoreFull.Data.SchoolContext context)
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

            var agrisectortype =  await _context.AgriSectorType.FirstOrDefaultAsync(m => m.Id == id);
            if (agrisectortype == null)
            {
                return NotFound();
            }
            AgriSectorType = agrisectortype;
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

            _context.Attach(AgriSectorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgriSectorTypeExists(AgriSectorType.Id))
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

        private bool AgriSectorTypeExists(int id)
        {
          return (_context.AgriSectorType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
