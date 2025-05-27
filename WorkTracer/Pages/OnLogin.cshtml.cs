using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkTracer.Services;

public class OnLogin : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public OnLogin(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public async Task<IActionResult> OnGetAsync(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return Redirect("/"); // Go to home or protected page
        }

        return Redirect("/login?error=true");
    }
    
    public async Task<IActionResult> OnPostAsync(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return Redirect("/"); // Go to home or protected page
        }

        return Redirect("/login?error=true");
    }
}