using Microsoft.AspNetCore.Mvc;

namespace ServiceMS.Controllers;

public class TrackController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}