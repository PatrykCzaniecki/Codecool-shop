using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Areas.Identity.Data;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.JSON;
using Codecool.CodecoolShop.Models;
using Data;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Address = Codecool.CodecoolShop.Models.Address;
using Order = Codecool.CodecoolShop.Models.Order;
using PaymentInfo = Codecool.CodecoolShop.Models.PaymentInfo;

namespace Codecool.CodecoolShop.Controllers;

public class ModelOrderConfirmationContainer
{
    public Domain.Order order { get; set; }
    public List<OrderedProduct> products { get; set; }

}
public class OrderConfirmationController : Controller
{
    private readonly CodecoolShopContext _context;
    private readonly ILogger<ProductController> _logger;
    private readonly UserManager<CodecoolCodecoolShopUser> _userManager;

    public OrderConfirmationController(ILogger<ProductController> logger, CodecoolShopContext context, UserManager<CodecoolCodecoolShopUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = _userManager.GetUserId(User);
            var order = _context.Orders
                .Include(o => o.Address)
                .Include(o => o.PaymentInfo)
                .First(o => o.User_id == userId);
            var orderedProducts = _context.OrderedProducts
                .Include(p => p.Order)
                .Where(p => p.Order.User_id == userId)
                .ToList();
            var model = new ModelOrderConfirmationContainer {order = order, products = orderedProducts};
            return View(model);
        }

        return RedirectToAction("Index", "Product");
    }

    [HttpPost]
    public IActionResult Send()
    {
        var adressDaoMemory = AddressDaoMemory.GetInstance();
        Email.SendEmail(adressDaoMemory.adress.Email);
        ClearOrder();
        return RedirectToAction("Confirmation");
    }

    private void ClearOrder()
    {
        var adressDaoMemory = AddressDaoMemory.GetInstance();
        var cartDaoMemory = CartDaoMemory.GetInstance();
        var orderDataStore = OrderDaoMemory.GetInstance();
        var productDaoMemory = ProductDaoMemory.GetInstance();
        JsonFile.SaveToJsonFile(orderDataStore.order, 1);
        adressDaoMemory.adress = new Address();
        cartDaoMemory.cart = new Cart();
        orderDataStore.order = new Order();
        orderDataStore.paymentInfo = new PaymentInfo();
        productDaoMemory.Clear();
    }

    public IActionResult Confirmation()
    {
        return View();
    }
}