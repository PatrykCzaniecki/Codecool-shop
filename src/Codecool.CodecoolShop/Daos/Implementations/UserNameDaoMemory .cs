using System;
using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class UserNameDaoMemory : IUserNameDao
{
    private static UserNameDaoMemory instance;

    public LoginInfo loginInfo = new();

    private UserNameDaoMemory()
    {
    }


    public static UserNameDaoMemory GetInstance()
    {
        if (instance == null) instance = new UserNameDaoMemory();

        return instance;
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