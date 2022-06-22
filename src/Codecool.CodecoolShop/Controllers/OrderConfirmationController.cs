using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.JSON;
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
        ProductDaoMemory productDaoMemory = ProductDaoMemory.GetInstance();
        JsonFile.SaveToJsonFile(orderDataStore.order,1);
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