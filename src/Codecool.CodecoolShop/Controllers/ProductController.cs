using System.Diagnostics;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly CartDaoMemory cartDaoMemory;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
        ProductService = new ProductService(
            ProductDaoMemory.GetInstance(),
            ProductCategoryDaoMemory.GetInstance());
        cartDaoMemory = CartDaoMemory.GetInstance();
    }

    public ProductService ProductService { get; set; }


    public IActionResult Index()
    {
        var products = ProductService.GetProductsForCategory(1);
        return View(products.ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Add(int? id)
    {
        cartDaoMemory.AddProductToCart(id);
        return RedirectToAction("Index");
    }

    public IActionResult Minus(int? id)
    {
        cartDaoMemory.MinusProductFromCart(id);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        cartDaoMemory.DeleteProductFromCart(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}