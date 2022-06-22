using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.JSON;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers;


public class OrderConfirmationController : Controller
{

    public IActionResult Index()
    {
        AddressDaoMemory adressDaoMemory = AddressDaoMemory.GetInstance();
        CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();
        OrderDaoMemory orderDataStore = OrderDaoMemory.GetInstance();
        Order order = new Order();

        order.Address = adressDaoMemory.adress;
        order.Cart = cartDaoMemory.cart;
        order.PaymentInfo = orderDataStore.paymentInfo;

        return View(order);
    }
}