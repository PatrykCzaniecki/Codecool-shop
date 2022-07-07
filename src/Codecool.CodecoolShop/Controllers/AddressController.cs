using System;
using System.Diagnostics;
using System.Linq;
using Codecool.CodecoolShop.Areas.Identity.Data;
using Codecool.CodecoolShop.Models;
using Data;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class AddressController : Controller
{
    private readonly CodecoolShopContext _context;
    private readonly ILogger<AddressController> _logger;
    private readonly UserManager<CodecoolCodecoolShopUser> _userManager;

    public AddressController(ILogger<AddressController> logger, CodecoolShopContext context,
        UserManager<CodecoolCodecoolShopUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        _logger.LogInformation($"Address page viewed on {DateTime.Now}");
        return View();
    }

    [HttpPost]
    [AcceptVerbs]
    public IActionResult Index(Address addressGet)
    {
        _logger.LogInformation($"{DateTime.Now} Action Controller HttpPost executed");
        if (!ModelState.IsValid)
        {
            _logger.LogInformation($" {DateTime.Now} Modelstate is not valid.");
            return View();
        }

        if (User.Identity.IsAuthenticated)
        {
            _logger.LogInformation($" {DateTime.Now} adding provided information into DB.");
            var userId = _userManager.GetUserId(User);
            var addressId = _context.Orders.Where(o => o.User_id == userId && o.OrderPayed == "No")
                .Select(o => o.Address.Id).First();
            var address = _context.Addresses.First(a => a.Id == addressId);
            address.Phone = addressGet.Phone;
            address.City = addressGet.City;
            address.Country = addressGet.Country;
            address.Email = addressGet.Email;
            address.FullName = addressGet.FullName;
            address.Street = addressGet.Street;
            address.Zip = addressGet.Zip;
            _context.SaveChanges();
        }
        //var address = AddressDaoMemory.GetInstance();
        //address.adress = addressGet;


        return RedirectToAction("Index", "Payment");
    }

    public IActionResult Submit(IFormCollection collection)
    {
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogInformation($"Error on: {DateTime.Now}");
        return RedirectToAction("Index", "Product");
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}