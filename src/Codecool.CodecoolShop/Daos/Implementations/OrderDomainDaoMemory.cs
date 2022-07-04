using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class OrderDomainDaoMemory : IOrderDomainDao
{
    private static OrderDomainDaoMemory instance;
    private readonly List<Order> data = new();

    private OrderDomainDaoMemory()
    {
    }

    public void Add(Order item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public Order Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<Order> GetAll()
    {
        return data;
    }


    public static OrderDomainDaoMemory GetInstance()
    {
        if (instance == null) instance = new OrderDomainDaoMemory();

        return instance;
    }
}