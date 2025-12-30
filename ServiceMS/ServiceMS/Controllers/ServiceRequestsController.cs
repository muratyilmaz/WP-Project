using Microsoft.AspNetCore.Mvc;

namespace ServiceMS.Controllers;

public class ServiceRequestsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}