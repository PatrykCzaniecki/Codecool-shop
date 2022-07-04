using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers;

public class SignUpController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}