using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;
using ServiceMS.Models.Db;

namespace ServiceMS.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;
    public HomeController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    // GET
    public IActionResult Create()  {  return View(); }
    
    [HttpPost]
    public IActionResult Create(service_request model)
    {
        model.tracking_code = Guid.NewGuid().ToString()[..12];
        model.created_at = DateTime.UtcNow;
        model.updated_at = DateTime.UtcNow;
        model.status = 0;

        _db.service_requests.Add(model);
        _db.SaveChanges();
        
        return RedirectToAction("Index"); ;
    }
}
