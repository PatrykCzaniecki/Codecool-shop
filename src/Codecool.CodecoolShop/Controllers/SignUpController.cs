using System.Diagnostics;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class SignUpController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    private readonly ILogger<SignUpController> _logger;

    public SignUpController(ILogger<SignUpController> logger)
    {
        _logger = logger;
    }

    public IActionResult Submit(IFormCollection collection)
    {
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}