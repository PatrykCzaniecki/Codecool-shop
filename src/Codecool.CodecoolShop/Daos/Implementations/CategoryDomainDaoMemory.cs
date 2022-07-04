using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class CategoryDomainDaoMemory : ICategoryDomainDao
{
    private static CategoryDomainDaoMemory instance;
    private readonly List<Category> data = new();

    private CategoryDomainDaoMemory()
    {
    }

    public void Add(Category item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public Category Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<Category> GetAll()
    {
        return data;
    }


    public static CategoryDomainDaoMemory GetInstance()
    {
        if (instance == null) instance = new CategoryDomainDaoMemory();

        return instance;
    }
}