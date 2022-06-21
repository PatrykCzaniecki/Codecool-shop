using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers;

[Route("payment")]
public class PaymentController : Controller
{
    private readonly CartDaoMemory cartDaoMemory = CartDaoMemory.GetInstance();

    [Route("index")]
    public IActionResult Index(IFormCollection collection)
    {
        IOrderDao orderDataStore = OrderDaoMemory.GetInstance();

        var order = new Order
        {
            Cart = cartDaoMemory.cart,
            PaymentInfo = new PaymentInfo(),
            Total = cartDaoMemory.cart.TotalPrice(),
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