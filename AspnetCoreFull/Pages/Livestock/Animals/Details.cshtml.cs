using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Pages.Livestock.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly AspnetCoreFull.Data.AnalyticaContext _context;
        public Dictionary<string, List<decimal?>> ChartDataDict { get; set; }
        public List<string> Labels { get; set; }
        public List<string> ChartIdentifiers { get; set; }

        public DetailsModel(AspnetCoreFull.Data.AnalyticaContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.Gender) // Include Gender
                .Include(a => a.AnimalType) // Include AnimalType
                .FirstOrDefaultAsync(m => m.Id == id);

            if (animal == null)
            {
                return NotFound();
            }
            else
            {
                Animal = animal;
            }

            // Fetch AnimalProgress records for this animal
            var animalProgressList = await _context.AnimalProgresses
                .Where(ap => ap.AnimalId == id)
                .Include(ap => ap.AnimalProgressType)
                .ToListAsync();

            // Group by AnimalProgressType and prepare chart data
            ChartDataDict = new Dictionary<string, List<decimal?>>();
            ChartIdentifiers = new List<string>();

            // Convert DateTime to String for labels
            Labels = animalProgressList
                .Select(ap => ap.Date.ToString("MM/dd/yyyy")) // Format the date as needed
                .Distinct()
                .OrderBy(date => date) // Optional: order by date
                .ToList();

            foreach (var group in animalProgressList.GroupBy(ap => ap.AnimalProgressType.Name))
            {
                ChartIdentifiers.Add(group.Key);
                ChartDataDict[group.Key] = group.Select(ap => ap.Value).ToList();
            }

            return Page();
        }
    }
}
