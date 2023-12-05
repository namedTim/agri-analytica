using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock
{
    public class CreateModel : PageModel
    {
        private readonly AspnetCoreFull.Data.SchoolContext _context;

        public CreateModel(AspnetCoreFull.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AgriSectorType AgriSectorType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AgriSectorType == null || AgriSectorType == null)
            {
                return Page();
            }

            _context.AgriSectorType.Add(AgriSectorType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
