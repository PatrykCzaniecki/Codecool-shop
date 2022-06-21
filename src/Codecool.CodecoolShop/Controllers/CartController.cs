using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;
    private readonly CartDaoMemory cartDaoMemory;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
        cartDaoMemory = CartDaoMemory.GetInstance();
    }

    public IActionResult Index()
    {
        Email.SendEmail();
        return View(cartDaoMemory.cart);
    }

    public IActionResult Add(int? id)
    {
        cartDaoMemory.AddProductToCart(id);
        return RedirectToAction("Index");
    }

    public IActionResult Minus(int? id)
    {
        cartDaoMemory.MinusProductFromCart(id);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        cartDaoMemory.DeleteProductFromCart(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}