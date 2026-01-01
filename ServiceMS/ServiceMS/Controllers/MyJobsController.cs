using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;
using ServiceMS.Models.Db;

namespace ServiceMS.Controllers;

[Authorize(Roles = "Admin,Technician")]
public class MyJobsController(AppDbContext db) : Controller
{
    // GET
    public IActionResult Index()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(userIdStr, out var userId))
            return RedirectToAction("Login", "Auth");

        var query = db.service_requests.AsQueryable();
        
        if (User.IsInRole("Technician"))
        {
            query = query.Where(x => x.assigned_technician_id == userId && x.status != 2);
        }
        else if (User.IsInRole("Admin"))
        {
            query = query.Where(x => x.assigned_technician_id == userId);
        }

        var list = query.OrderByDescending(x => x.updated_at).ToList();
        return View(list);
    }

    [HttpGet]
    public IActionResult Detail(long id)
    {
        var item = db.service_requests.FirstOrDefault(x => x.id == id);
        return View(item);
    }

    [HttpPost]
    public IActionResult UpdateStatus(service_request model)
    {
        var item = db.service_requests.FirstOrDefault(x => x.id == model.id);
        if (item == null)
            return NotFound();
        item.status = model.status;
        db.SaveChanges();
        return RedirectToAction("Index",  "MyJobs");
    }
}