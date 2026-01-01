using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceMS.Data;
using ServiceMS.Helpers;
using ServiceMS.Models.Db;

namespace ServiceMS.Controllers;

[Authorize(Roles = "Admin,Clerk")]
public class ServiceRequestsController(AppDbContext db) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var query = db.service_requests.AsQueryable();
        
        if (User.IsInRole("Clerk"))
        {
            query = query.Where(d => d.status != 3);
        }
        
        var list = query.OrderBy(d => d.created_at).ToList();
        return View(list);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(service_request model)
    {
        var val = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(val, out var userId))
            return RedirectToAction("Login", "Auth");

        model.tracking_code = TrackingCodeGenerator.Generate();
        model.created_at = DateTime.UtcNow;
        model.updated_at = DateTime.UtcNow;
        model.assigned_technician_id = null;
        model.created_by_user_id = userId;
        
        db.service_requests.Add(model);
        db.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(long id)
    {
        var item = db.service_requests
            .Include(x => x.assigned_technician)
            .FirstOrDefault(x => x.id == id);
        
        if (item == null)
            return NotFound();
        
        return View(item);
    }

    [HttpGet]
    public IActionResult Edit(long id)
    {
        var item = db.service_requests
            .Include(x => x.assigned_technician)
            .FirstOrDefault(x => x.id == id);
        
        if (item == null)
            return NotFound();
        
        var technicians = db.users
            .Where(u => u.role == "Technician")
            .OrderBy(u => u.username)
            .ToList();

        ViewBag.Technicians = technicians;

        return View(item);
    }

    [HttpPost]
    public IActionResult Edit(service_request model)
    {
        var entity = db.service_requests
            .FirstOrDefault(x => x.id == model.id);

        if (entity == null)
            return NotFound();

        entity.customer_name = model.customer_name;
        entity.customer_phone = model.customer_phone;
        entity.device_name = model.device_name;
        entity.issue_description = model.issue_description;
        entity.status = model.status;
        entity.assigned_technician_id = model.assigned_technician_id;
        entity.updated_at = DateTime.UtcNow;
        
        db.SaveChanges();
        
        return RedirectToAction("Details", new { id = model.id });
    }
}