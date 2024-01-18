using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCoreFull.Pages.Auth.Register
{
  public class BasicModel : PageModel
  {
    public void OnGet() { }
  }
  public class CoverModel : PageModel
  {
    public void OnGet() { }
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AnalyticaContext _context;

    public CoverModel(UserManager<IdentityUser> userManager, AnalyticaContext context)
    {
      _userManager = userManager;
      _context = context;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
      [Required]
      public string Username { get; set; }

      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }
    }

    // Bind properties, constructor, OnPostAsync method, etc.

    public async Task<IActionResult> OnPostAsync()
    {
      if (ModelState.IsValid)
      {
        var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
        var result = await _userManager.CreateAsync(user, Input.Password);
        if (result.Succeeded)
        {
          // User creation logic here (e.g., sign-in the user)
          var userId = await _userManager.GetUserIdAsync(user);

          await ExtendUserReach(userId);

          return RedirectToPage("../Login/Cover");
        }
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      // If we got this far, something failed, redisplay form
      return Page();
    }

    private async Task ExtendUserReach(string userId)
    {
      var usr = new User()
      {
        AspUserId = userId
      };
      var result = await _context.Users.AddAsync(usr);
      var fld = new AgriSectorType()
      {
        AspUserId = userId,
        Name = "Živinoreja",
      };

      await _context.AgriSectorTypes.AddAsync(fld);
      //Save changes to the db
      await _context.SaveChangesAsync();
    }
  }
  public class MultiStepsModel : PageModel
  {
    public void OnGet() { }
  }
}
