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
        return View();
    }

    [HttpPost]
    [AcceptVerbs]
    public IActionResult Index(Address addressGet)
    {
        if (!ModelState.IsValid) return View();

        if (User.Identity.IsAuthenticated)
        {
            var userId = _userManager.GetUserId(User);
            var addresId = _context.Orders.Where(o => o.User_id == userId && o.OrderPayed == "No")
                .Select(o => o.Address.Id).First();
            var address = _context.Addresses.First(a => a.Id == addresId);
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
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}