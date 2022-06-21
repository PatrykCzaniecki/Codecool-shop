using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public static CartDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new CartDaoMemory();
            }

            return instance;
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
    }
}
