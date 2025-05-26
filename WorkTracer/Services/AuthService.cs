using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

public class AuthService : Controller
{
    public bool isLoggedIn { get; set; }
    private readonly UserRecord users;

    public AuthService(UserRecord usr)
    {
        users = usr;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CookieLogin([FromForm] LoginModel model)
    {
        if (!await users.ValidateCredentialsAsync(model.Username, model.Password))
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View("Login", model);
        }

        // Generate the claims
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, model.Username));
        claims.Add(new Claim(ClaimTypes.Role, "User"));

        var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Auth"));

        await HttpContext.SignInAsync("Auth", principal).ConfigureAwait(false);
        
        isLoggedIn = true;
        return Redirect("/");
    }
    
    [HttpPost]
    public async Task<IActionResult> CookieLogout()
    {
        await HttpContext.SignOutAsync("Auth").ConfigureAwait(false);
        return Redirect("/login");
    }
}