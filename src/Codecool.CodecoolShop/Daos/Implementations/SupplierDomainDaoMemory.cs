using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class SupplierDomainDaoMemory : ISupplierDomainDao
{
    private static SupplierDomainDaoMemory instance;
    private readonly List<Supplier> data = new();

    private SupplierDomainDaoMemory()
    {
    }

    public void Add(Supplier item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public Supplier Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<Supplier> GetAll()
    {
        return data;
    }


    public static SupplierDomainDaoMemory GetInstance()
    {
        if (instance == null) instance = new SupplierDomainDaoMemory();

        return instance;
    }
}