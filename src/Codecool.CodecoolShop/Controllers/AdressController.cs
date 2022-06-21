using System;
using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class AdressController : Controller
    {
        private readonly ILogger<AdressController> _logger;

        public AdressController(ILogger<AdressController> logger)
        {
            _logger = logger;
        }
        public Address address;

        public IActionResult Index()
        {
            var cartDaoMemory = CartDaoMemory.GetInstance();
            return View();
        }

        public IActionResult Submit(object sender, EventArgs e)
        {
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
