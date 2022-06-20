using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();
            return View(cartDaoMemory.cart);
        }

        public IActionResult Add(int? id)
        {
            ProductDaoMemory productDaoMemory = ProductDaoMemory.GetInstance();
            if (id != null)
            {
                Product product = productDaoMemory.Get((int)id);
                CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();
                cartDaoMemory.Add(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            ProductDaoMemory productDaoMemory = ProductDaoMemory.GetInstance();
            if (id != null)
            {
                Product product = productDaoMemory.Get((int)id);
                CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();
                cartDaoMemory.Remove(product);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
