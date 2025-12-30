using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;

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

        var list = db.service_requests.Where(x => x.assigned_technician_id == userId)
            .OrderByDescending(x => x.updated_at)
            .ToList();
        return View(list);
    }
}