using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class OrderDaoMemory : IOrderDao
{
    private static OrderDaoMemory _instance;
    private readonly List<Order> _data = new();
    public PaymentInfo paymentInfo;
    public Order order;

    private OrderDaoMemory()
    {
    }


    public static OrderDaoMemory GetInstance()
    {
        if (_instance == null) _instance = new OrderDaoMemory();

        return _instance;
    }

    public void Add(Order item)
    {
        throw new System.NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new System.NotImplementedException();
    }

    public Order Get(int id)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Order> GetAll()
    {
        throw new System.NotImplementedException();
    }
}