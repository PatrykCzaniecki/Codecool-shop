using System.Diagnostics;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Address = Domain.Address;
using Order = Domain.Order;

namespace Codecool.CodecoolShop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;
    private readonly CartDaoMemory cartDaoMemory;
    private readonly CodecoolShopContext _context;

    public CartController(ILogger<CartController> logger, CodecoolShopContext context)
    {
        _logger = logger;
        cartDaoMemory = CartDaoMemory.GetInstance();
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.OrderedProducts.ToList();
        return View(products);
    }

    public IActionResult Add(int? id)
    {
        if (ProductAlreadyInCart(id))
        {
            IncreaseProductQuantity(id);
        }
        else
        {
            AddNewProductToCart(id);
        }
        return RedirectToAction("Index");
    }

    private void IncreaseProductQuantity(int? id)
    {
        var product = _context.OrderedProducts.First(p => p.ProductId == id);
        product.Quantity++;
        _context.SaveChanges();
    }

    private void AddNewProductToCart(int? id)
    {
        var product = _context.Products.Where(p => p.Id == id).First();
        var address = new Address
        {
            City = "",
            Country = "",
            Email = "",
            FullName = "",
            Phone = "",
            Street = "",
            Zip = ""
        };
        var order = new Order { Address = address };
        var orderedProduct = new OrderedProduct
        {
            Currency = product.Currency,
            Name = product.Name,
            Price = product.DefaultPrice,
            Order = order,
            ProductId = product.Id,
            Quantity = 1
        };
        _context.Addresses.Add(address);
        _context.Orders.Add(order);
        _context.OrderedProducts.Add(orderedProduct);
        _context.SaveChanges();
    }

    private bool ProductAlreadyInCart(int? id)
    {
        return _context.OrderedProducts.Any(p => p.ProductId == id);
    }

    public IActionResult Minus(int? id)
    {
        if (ProductAlreadyInCart(id))
        {
            DecreaseProductQuantity(id);
        }
        return RedirectToAction("Index");
    }

    private void DecreaseProductQuantity(int? id)
    {
        var product = _context.OrderedProducts.First(p => p.ProductId == id);
        product.Quantity--;
        if (product.Quantity == 0)
            _context.OrderedProducts.Remove(product);
        _context.SaveChanges();
    }

    public IActionResult Delete(int? id)
    {
        if (ProductAlreadyInCart(id))
        {
            var product = _context.OrderedProducts.First(p => p.ProductId == id);
            _context.OrderedProducts.Remove(product);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}