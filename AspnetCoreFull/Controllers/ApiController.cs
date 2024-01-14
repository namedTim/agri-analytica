using AspnetCoreFull.Data;
using AspnetCoreFull.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreFull.Controllers;

[Route("api/v1/User")]
[ApiController]
[ApiKeyAuth]
public class ApiController : ControllerBase
{
  private readonly AnalyticaContext _context;

  public ApiController(AnalyticaContext context)
  {
    _context = context;
  }

  // Test API endpoint
  [HttpGet("Test")]
  public IActionResult TestApi()
  {
    return Ok("API is working correctly.");
  }
}
