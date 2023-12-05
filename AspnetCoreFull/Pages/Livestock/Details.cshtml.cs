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
    public class DetailsModel : PageModel
    {
        private readonly AspnetCoreFull.Data.SchoolContext _context;

        public DetailsModel(AspnetCoreFull.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
