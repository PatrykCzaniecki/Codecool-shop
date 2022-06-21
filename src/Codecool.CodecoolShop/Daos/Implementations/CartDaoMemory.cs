using System;
using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDaoMemory : ICartDao
    {
        public Cart cart = new Cart();
        private static CartDaoMemory instance = null;
        private ProductDaoMemory productDaoMemory = ProductDaoMemory.GetInstance();

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

        public void AddProductToCart(int? id)
        {
            if (id != null)
            {
                Product product = productDaoMemory.Get((int)id);
                cart.AddProduct(product);
            }
        }

        public void RemoveProductFromCart(int? id)
        {
            if (id != null)
            {
                Product product = productDaoMemory.Get((int)id);
                cart.RemoveProduct(product);
            }
        }


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