using System.Collections.Generic;
using Domain;


namespace Codecool.CodecoolShop.Daos.Implementations;

public class UserDomainDaoMemory : IUserDomainDao
{
    private static UserDomainDaoMemory instance;
    private readonly List<User> data = new();

    private UserDomainDaoMemory()
    {
    }

    public void Add(User item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public User Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<User> GetAll()
    {
        return data;
    }


    public static UserDomainDaoMemory GetInstance()
    {
        if (instance == null) instance = new UserDomainDaoMemory();

        return instance;
    }
}