using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkTracer.Services;

public class OnLogout : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public OnLogout(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnGet()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/"); // Go to home or protected page
    }
}