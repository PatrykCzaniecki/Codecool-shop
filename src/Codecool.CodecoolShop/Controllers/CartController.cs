using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private CartDaoMemory cartDaoMemory;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            cartDaoMemory = CartDaoMemory.GetInstance();
        }

        public IActionResult Index()
        {
            return View(cartDaoMemory.cart);
        }

        public IActionResult Add(int? id)
        {
            cartDaoMemory.AddProductToCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            cartDaoMemory.RemoveProductFromCart(id);
            return RedirectToAction("Index");
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}