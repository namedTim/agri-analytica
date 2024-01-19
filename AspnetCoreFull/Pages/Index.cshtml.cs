using AspnetCoreFull.Data;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreFull.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;
  private readonly AnalyticaContext _context;
  private readonly UserManager<IdentityUser> _userManager;

  public Dictionary<string, int> AnimalTypesCount { get; set; }
  public Dictionary<string, string> AnimalTypeColors { get; set; }

  public List<string> GenerateColorShades(string color1, string color2, int count)
  {
    var colorShades = new List<string>();
    var startColor = System.Drawing.ColorTranslator.FromHtml(color1);
    var endColor = System.Drawing.ColorTranslator.FromHtml(color2);

    for (int i = 0; i < count; i++)
    {
      float ratio = i / (float)(count - 1);
      int red = (int)(startColor.R * (1 - ratio) + endColor.R * ratio);
      int green = (int)(startColor.G * (1 - ratio) + endColor.G * ratio);
      int blue = (int)(startColor.B * (1 - ratio) + endColor.B * ratio);

      colorShades.Add(System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(red, green, blue)));
    }

    return colorShades;
  }


  public IndexModel(ILogger<IndexModel> logger, AnalyticaContext context, UserManager<IdentityUser> userManager)
  {
    _logger = logger;
    _context = context;
    _userManager = userManager;
  }


  public async Task OnGetAsync()
  {
    var user = await _userManager.GetUserAsync(User); // Get the currently logged in user
    if (user == null)
    {
      return;
    }

    // Get the ID of the AgriSectorType with the name "Živinoreja" for the current user
    var sectorId = await _context.AgriSectorTypes
      .Where(s => s.AspUserId == user.Id && s.Name == "Živinoreja")
      .Select(s => s.Id)
      .FirstOrDefaultAsync();

    AnimalTypesCount = await _context.Animals
      .Where(a => a.AgriSectorId == sectorId) // Assuming OwnerId links Animal to User
      .GroupBy(a => a.AnimalType.Name)
      .Select(g => new { AnimalTypeName = g.Key, Count = g.Count() })
      .ToDictionaryAsync(g => g.AnimalTypeName, g => g.Count);

    // Define primary and secondary colors
    string primaryColor = "#0C4D50"; // "rgb(12,77,80)" in hex
    string secondaryColor = "#78933B"; // "rgb(120,147,59)" in hex

    int animalTypeCount = AnimalTypesCount.Count;
    var colorShades = GenerateColorShades(primaryColor, secondaryColor, animalTypeCount);

    AnimalTypeColors = new Dictionary<string, string>();
    int index = 0;
    foreach (var animalType in AnimalTypesCount.Keys)
    {
      AnimalTypeColors[animalType] = colorShades[index % colorShades.Count];
      index++;
    }
  }
}
