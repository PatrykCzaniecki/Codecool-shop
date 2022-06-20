using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        [Route("index")]
        public IActionResult Index(IFormCollection collection)
        {
            var cart = JsonFile.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            IOrderDao orderDataStore = OrderDaoMemory.GetInstance();

            Order order = new Order
            {
                ItemCollection = cart,
                PaymentInfo = new PaymentInfo(),
                Total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity),
                FullName = collection["fullname"],
                Email = collection["email"],
                Address = collection["address"],
                Country = collection["country"],
                City = collection["city"],
                Zip = collection["zip"],
                FullNameShipping = collection["fullnameShipping"],
                EmailShipping = collection["emailShipping"],
                AddressShipping = collection["addressShipping"],
                CountryShipping = collection["countryShipping"],
                CityShipping = collection["cityShipping"],
                ZipShipping = collection["zipShipping"]
            };

            orderDataStore.Add(order);

            return View();
        }
    }
}
