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
        orderDataStore.order = order;

        return View(order);
    }

    [HttpPost]
    public IActionResult Send()
    {
        AddressDaoMemory adressDaoMemory = AddressDaoMemory.GetInstance();
        Email.SendEmail(adressDaoMemory.adress.Email);
        ClearOrder();
        return RedirectToAction("Confirmation");
    }

    private void ClearOrder()
    {
        AddressDaoMemory adressDaoMemory = AddressDaoMemory.GetInstance();
        CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();
        OrderDaoMemory orderDataStore = OrderDaoMemory.GetInstance();
        adressDaoMemory.adress = null;
        cartDaoMemory.cart = null;
        orderDataStore.order = null;
        orderDataStore.paymentInfo = null;
    }

    public IActionResult Confirmation()
    {
        return View();
    }
}