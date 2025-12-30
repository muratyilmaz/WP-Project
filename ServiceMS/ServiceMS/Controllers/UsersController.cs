using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;
using ServiceMS.Helpers;
using ServiceMS.Models.Db;

namespace ServiceMS.Controllers;

[Authorize(Roles = "Admin")]
public class UsersController(AppDbContext db) : Controller
{
    private readonly AppDbContext _db = db;
    
    [HttpGet]
    public IActionResult Index()
    {
        var list = _db.users
            .OrderBy(u => u.id)
            .ToList();
        
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(string username, string password, string role)
    {
        var exists = _db.users.Any(x => x.username == username);
        if (exists)
        {
            ViewBag.Error = "Bu username zaten kullanılıyor.";
            return View();
        }

        var user = new user
        {
            username = username,
            password_hash = PasswordHasher.Hash(password),
            role = role
        };
        
        _db.users.Add(user);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}