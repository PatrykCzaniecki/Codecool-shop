using System.Collections.Generic;

<<<<<<< HEAD
namespace Codecool.CodecoolShop.Daos
{
    public interface IDao<T>
    {
        void Add(T item);
        void Remove(int id);

        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
=======
namespace Codecool.CodecoolShop.Daos;

public interface IDao<T>
{
    void Add(T item);
    void Remove(int id);

    T Get(int id);
    IEnumerable<T> GetAll();
}
>>>>>>> r1remote/development
