using System;
using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class CartDaoMemory : ICartDao
{
    private static CartDaoMemory instance;
    public Cart cart = new();
    private List<Cart> cartList = new();

    private CartDaoMemory()
    {
    }

    public void Add(Cart item)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Cart Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Cart> GetAll()
    {
        throw new NotImplementedException();
    }

    public static CartDaoMemory GetInstance()
    {
        if (instance == null) instance = new CartDaoMemory();

        return instance;
    }

    public void Add(Product item)
    {
        cart.AddProduct(item);
    }

    public void Remove(Product item)
    {
        cart.RemoveProduct(item);
    }

    public Cart Get()
    {
        return cart;
    }
}