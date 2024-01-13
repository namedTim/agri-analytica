using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCoreFull.Pages.Auth.Login
{
  public class BasicModel : PageModel
  {
    public void OnGet() { }
  }
  public class CoverModel : PageModel
  {
    public void OnGet() { }
    private readonly SignInManager<IdentityUser> _signInManager;

    public CoverModel(SignInManager<IdentityUser> signInManager)
    {
      _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
      [Required]
      public string EmailOrUsername { get; set; }

      [Required]
      [DataType(DataType.Password)]
      public string Password { get; set; }

      public bool RememberMe { get; set; }
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (ModelState.IsValid)
      {
        // Attempt to sign in the user
        var result = await _signInManager.PasswordSignInAsync(Input.EmailOrUsername, Input.Password, Input.RememberMe, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          // Redirect the user or return a success message
        }
        else if (result.IsLockedOut)
        {
          // Notify user of lockout
          ModelState.AddModelError(string.Empty, "Notify user of lockout");
          return Page();

        }
        else if (result.IsNotAllowed)
        {
          // Notify user they are not allowed to sign in (maybe they haven't confirmed their email)
          ModelState.AddModelError(string.Empty, "Notify user they are not allowed to sign in (maybe they haven't confirmed their email)");
          return Page();
        }
        else
        {
          ModelState.AddModelError(string.Empty, "Invalid login attempt.");
          return Page();
        }

        if (result.Succeeded)
        {
          return LocalRedirect(Url.Content("~/")); // Redirect to the home page or a different page as needed
        }
        else
        {
          // If login fails, add a generic error message
          ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
      }

      // If we got this far, something failed; redisplay the form
      return Page();
    }
  }
}
