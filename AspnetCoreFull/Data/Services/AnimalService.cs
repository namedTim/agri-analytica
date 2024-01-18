using AspnetCoreFull.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreFull.Data.Services;

public class AnimalService
{
  private readonly AnalyticaContext _context;

  public AnimalService(AnalyticaContext context)
  {
    _context = context;
  }

  public async Task<List<Animal>> GetAllAnimalsAsync()
  {
    return await _context.Animals.ToListAsync();
  }

  public async Task<List<Animal>> GetAnimalsForUser(string userId)
  {
    // First, get all the sector IDs associated with the user
    var userSectorIds = await _context.AgriSectorTypes
      .Where(sector => sector.AspUserId == userId)
      .Select(sector => sector.Id)
      .ToListAsync();

    // Then, get all animals where the AgriSectorId matches one of the user's sector IDs
    var animalsForUser = await _context.Animals
      .Where(animal => userSectorIds.Contains(animal.AgriSectorId))
      .ToListAsync();

    return animalsForUser;
  }

}
