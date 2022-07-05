using System.Diagnostics;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class SignUpController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ILogger<SignUpController> _logger;

    public SignUpController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult SignUp(SignUp dto)
    {
        _accountService.SignUpUser(dto);
        return RedirectToAction("Index", "Product");
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}