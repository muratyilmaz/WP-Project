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
        var user = db.Users
            .FirstOrDefault(x => x.Username == username && x.PasswordHash == hash);

        if (user == null)
        {
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
            return View("Error");
        }
        
        return View();
    }
}