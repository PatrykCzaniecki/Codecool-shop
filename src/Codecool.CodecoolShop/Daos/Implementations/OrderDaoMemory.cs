using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDaoMemory : IOrderDao
    {
        private List<Order> _data = new List<Order>();
        private static OrderDaoMemory _instance = null;

        private OrderDaoMemory()
        {
        }

        public static OrderDaoMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new OrderDaoMemory();
            }

            return _instance;
        }

        public void Add(Order item)
        {
            item.Id = _data.Count + 1;
            _data.Add(item);
        }

        public void Remove(int id)
        {
            _data.Remove(this.Get(id));
        }

        public Order Get(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _data;
        }
    }
}
