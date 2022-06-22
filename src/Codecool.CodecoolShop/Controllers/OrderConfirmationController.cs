using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers;

public class OrderConfirmationController : Controller
{
    public IActionResult Index()
    {
        var adressDaoMemory = AddressDaoMemory.GetInstance();
        var cartDaoMemory = CartDaoMemory.GetInstance();
        var orderDataStore = OrderDaoMemory.GetInstance();
        var order = new Order();

        order.Address = adressDaoMemory.adress;
        order.Cart = cartDaoMemory.cart;
        order.PaymentInfo = orderDataStore.paymentInfo;

        return View(order);
    }
}