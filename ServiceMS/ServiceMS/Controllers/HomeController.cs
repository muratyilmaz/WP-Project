using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;
using ServiceMS.Models;

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
    public IActionResult Create(ServiceRequest model)
    {
        model.TrackingCode = Guid.NewGuid().ToString()[..12];
        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedAt = DateTime.UtcNow;
        model.Status = ServiceStatus.Open;

        _db.ServiceRequests.Add(model);
        _db.SaveChanges();
        
        return RedirectToAction("Index"); ;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
