using Microsoft.AspNetCore.Mvc;

namespace ServiceMS.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}