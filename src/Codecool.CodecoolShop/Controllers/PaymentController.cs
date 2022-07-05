using System.Linq;
using Codecool.CodecoolShop.Areas.Identity.Data;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class PaymentController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly CodecoolShopContext _context;
    private readonly UserManager<CodecoolCodecoolShopUser> _userManager;

    public PaymentController(ILogger<ProductController> logger, CodecoolShopContext context, UserManager<CodecoolCodecoolShopUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        IOrderDao orderDataStore = OrderDaoMemory.GetInstance();

        return View();
    }

    [HttpPost]
    public IActionResult Index(PaymentInfo paymentInfoGet)
    {
        if (!ModelState.IsValid)
            return View();
        if (User.Identity.IsAuthenticated)
        {
            var userId = _userManager.GetUserId(User);
            var paymentId = _context.Orders
                .Include(o => o.PaymentInfo)
                .Where(o => o.User_id == userId)
                .Select(o => o.PaymentInfo.Id).First();
            var payment = _context.PaymentInfos.First(p => p.Id == paymentId);
            payment.CardNumber = paymentInfoGet.CardNumber;
            payment.ExpMonth = paymentInfoGet.ExpMonth;
            payment.ExpYear = paymentInfoGet.ExpYear;
            payment.CVV = paymentInfoGet.CVV;
            payment.NameOnCard = paymentInfoGet.NameOnCard;
            var order = _context.Orders
                .First(p => p.PaymentInfo.Id == paymentId);
            order.OrderPayed = "Yes";
            _context.SaveChanges();
        }

        return RedirectToAction("Index", "OrderConfirmation");
    }
}