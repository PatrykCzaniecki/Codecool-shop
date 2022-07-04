using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class AddressDomainDaoMemory : IAddressDomainDao
{
    private static AddressDomainDaoMemory instance;
    private readonly List<Address> data = new();

    private AddressDomainDaoMemory()
    {
    }

    public void Add(Address item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public Address Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<Address> GetAll()
    {
        return data;
    }


    public static AddressDomainDaoMemory GetInstance()
    {
        if (instance == null) instance = new AddressDomainDaoMemory();

        return instance;
    }
}