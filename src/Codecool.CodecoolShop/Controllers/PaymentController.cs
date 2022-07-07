using System.Linq;
using Codecool.CodecoolShop.Areas.Identity.Data;
using Data;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class PaymentController : Controller
{
    private readonly CodecoolShopContext _context;
    private readonly ILogger<ProductController> _logger;
    private readonly UserManager<CodecoolCodecoolShopUser> _userManager;

    public PaymentController(ILogger<ProductController> logger, CodecoolShopContext context,
        UserManager<CodecoolCodecoolShopUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
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
                .Where(o => o.User_id == userId && o.OrderPayed == "No")
                .Select(o => o.PaymentInfo.Id).First();
            var payment = _context.PaymentInfos.First(p => p.Id == paymentId);
            payment.CardNumber = paymentInfoGet.CardNumber;
            payment.ExpMonth = paymentInfoGet.ExpMonth;
            payment.ExpYear = paymentInfoGet.ExpYear;
            payment.CVV = paymentInfoGet.CVV;
            payment.NameOnCard = paymentInfoGet.NameOnCard;
            var order = _context.Orders
                .First(p => p.PaymentInfo.Id == paymentId);
            _context.SaveChanges();
        }

        return RedirectToAction("Index", "OrderConfirmation");
    }
}