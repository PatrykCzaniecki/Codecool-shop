using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class AddressController : Controller
{
    private readonly ILogger<AddressController> _logger;

    public AddressController(ILogger<AddressController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [AcceptVerbs]
    public IActionResult Index(Address addressGet)
    {
        if (!ModelState.IsValid) return View();

        var address = AddressDaoMemory.GetInstance();
        address.adress = addressGet;

        return RedirectToAction("Index", "Payment");
    }

    public IActionResult Submit(IFormCollection collection)
    {
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}