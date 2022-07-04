using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;
using Domain;
using Product = Codecool.CodecoolShop.Models.Product;
using Supplier = Codecool.CodecoolShop.Models.Supplier;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class OrderedProductDomainDaoMemory : IOrderedProductDomainDao
{
    private static OrderedProductDomainDaoMemory instance;
    private readonly List<OrderedProduct> data = new();

    private OrderedProductDomainDaoMemory()
    {
    }

    public void Add(OrderedProduct item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public OrderedProduct Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<OrderedProduct> GetAll()
    {
        return data;
    }


    public static OrderedProductDomainDaoMemory GetInstance()
    {
        if (instance == null) instance = new OrderedProductDomainDaoMemory();

        return instance;
    }
}