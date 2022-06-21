using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var cartDaoMemory = CartDaoMemory.GetInstance();
        return View(cartDaoMemory.cart);
    }

    public IActionResult Add(int? id)
    {
        var productDaoMemory = ProductDaoMemory.GetInstance();
        if (id != null)
        {
            var product = productDaoMemory.Get((int) id);
            var cartDaoMemory = CartDaoMemory.GetInstance();
            cartDaoMemory.Add(product);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Remove(int? id)
    {
        var productDaoMemory = ProductDaoMemory.GetInstance();
        if (id != null)
        {
            var product = productDaoMemory.Get((int) id);
            var cartDaoMemory = CartDaoMemory.GetInstance();
            cartDaoMemory.Remove(product);
        }

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}