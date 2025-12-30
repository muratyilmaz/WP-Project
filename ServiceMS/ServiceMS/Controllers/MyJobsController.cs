using Microsoft.AspNetCore.Mvc;

namespace ServiceMS.Controllers;

public class MyJobsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}