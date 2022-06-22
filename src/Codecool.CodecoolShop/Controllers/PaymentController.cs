using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers;

public class PaymentController : Controller
{
    private readonly CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();

    public IActionResult Index()
    {
        IOrderDao orderDataStore = OrderDaoMemory.GetInstance();

        return View();
    }
    [HttpPost]
    public IActionResult Index(PaymentInfo paymentInfoGet)
    {
        OrderDaoMemory orderDataStore = OrderDaoMemory.GetInstance();
        orderDataStore.paymentInfo = paymentInfoGet;

        return RedirectToAction("Index", "OrderConfirmation");
    }

}