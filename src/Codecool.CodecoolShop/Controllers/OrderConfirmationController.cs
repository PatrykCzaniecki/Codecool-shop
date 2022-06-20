﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("orderconfirmation")]
    public class OrderConfirmationController : Controller
    {
        [Route("index")]
        public IActionResult Index(IFormCollection collection)
        {
            IOrderDao orderDataStore = OrderDaoMemory.GetInstance();
            Order order = orderDataStore.Get(1);

            PaymentInfo paymentInfo = new PaymentInfo();
            paymentInfo.NameOnCard = collection["cardname"];
            paymentInfo.CardNumber = collection["cardnumber"];
            paymentInfo.ExpMonth = collection["expmonth"];
            paymentInfo.ExpYear = collection["expyear"];
            paymentInfo.CVV = collection["cvv"];

            order.PaymentInfo = paymentInfo;

            SessionHelper.SaveToJsonFile(order, order.Id);
            ViewBag.order = order;

            return View();
        }
    }
}
