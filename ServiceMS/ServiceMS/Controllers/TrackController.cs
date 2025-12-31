using Microsoft.AspNetCore.Mvc;
using ServiceMS.Data;
using ServiceMS.Helpers;

namespace ServiceMS.Controllers;

public class TrackController(AppDbContext db) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Query(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return BadRequest(new { ok = false, message = "Takip kodu boş olamaz." });
        
        code = code.Trim().ToUpperInvariant();
        var sr = db.service_requests.FirstOrDefault(x => x.tracking_code == code);
        
        if (sr == null)
            return NotFound(new { ok = false, message = "Bu takip kodu ile kayıt bulunamadı." });
        
        return Ok(new
        {
            ok = true,
            trackingCode = sr.tracking_code,
            status = sr.status,
            statusText = ServiceStatusHelper.ToText(sr.status),
            deviceName = sr.device_name,
            updatedAtUtc = sr.updated_at
        });
    }
}