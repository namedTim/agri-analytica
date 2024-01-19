using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspnetCoreFull.Pages.Livestock.Animals
{
  [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AnalyticaContext _context;
        private readonly UserManager<IdentityUser> _userManager; // Add UserManager service

        public IndexModel(AnalyticaContext context, UserManager<IdentityUser> userManager)
        {
          _context = context;
          _userManager = userManager; // Initialize UserManager
        }

        public IList<Animal> Animal { get;set; } = default!;

        public async Task OnGetAsync()
        {
          var user = await _userManager.GetUserAsync(User); // Get the currently logged in user
          if (user == null)
          {
            Animal = new List<Animal>(); // Or handle the case where there is no logged in user
            return;
          }

          // Get the ID of the AgriSectorType with the name "Živinoreja" for the current user
          var sectorId = await _context.AgriSectorTypes
            .Where(s => s.AspUserId == user.Id && s.Name == "Živinoreja")
            .Select(s => s.Id)
            .FirstOrDefaultAsync();

          if (_context.Animals != null && sectorId != 0)
          {
            Animal = await _context.Animals
              .Where(a => a.AgriSectorId == sectorId)
              .Include(a => a.AnimalType)
              .Include(a => a.Gender)
              .ToListAsync();
          }
        }
    }
}
