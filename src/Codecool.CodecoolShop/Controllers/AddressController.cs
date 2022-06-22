using System;
using System.Diagnostics;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;


namespace Codecool.CodecoolShop.Controllers;

    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

    [HttpPost]
    public IActionResult Index(Address addressGet)
    {
        var address = AddressDaoMemory.GetInstance();
        address.adress = addressGet;

        return RedirectToAction();
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

        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }
}

