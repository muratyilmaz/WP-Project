using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;
using ServiceMS.Helpers;

namespace ServiceMS.Controllers;

public class AuthController(AppDbContext db) : Controller
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var hash = PasswordHasher.Hash(password);
        var user = db.users
            .FirstOrDefault(x => x.username == username && x.password_hash == hash);

        if (user == null)
        {
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
            return View();
        }
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
            new Claim(ClaimTypes.Name, user.username),
            new Claim(ClaimTypes.Role, user.role)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal)
            .GetAwaiter().GetResult();
        
        return user.role == "Admin" 
            ? RedirectToAction("Index", "Users") 
            : RedirectToAction("Index", "ServiceRequests");
    }
    
    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
            .GetAwaiter().GetResult();
        return RedirectToAction("Login", "Auth");
    }

    [HttpGet]
    public IActionResult Denied()
    {
        return View();
    }
}