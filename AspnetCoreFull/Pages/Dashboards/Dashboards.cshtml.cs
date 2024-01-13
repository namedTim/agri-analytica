using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCoreFull.Pages.Dashboards
{
  [Authorize]
  public class AnalyticsModel : PageModel
  {
    public void OnGet() { }
  }
  public class CrmModel : PageModel
  {
    public void OnGet() { }
  }
  public class EcommerceModel : PageModel
  {
    public void OnGet() { }
  }
}
