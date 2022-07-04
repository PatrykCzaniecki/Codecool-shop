using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

<<<<<<< HEAD
namespace Codecool.CodecoolShop.Daos.Implementations
{
    class ProductCategoryDaoMemory : IProductCategoryDao
    {
        private List<ProductCategory> data = new List<ProductCategory>();
        private static ProductCategoryDaoMemory instance = null;

        private ProductCategoryDaoMemory()
        {
        }

        public static ProductCategoryDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategoryDaoMemory();
            }

            return instance;
        }

        public void Add(ProductCategory item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public ProductCategory Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return data;
        }
    }
}
=======
namespace Codecool.CodecoolShop.Daos.Implementations;

internal class ProductCategoryDaoMemory : IProductCategoryDao
{
    private static ProductCategoryDaoMemory instance;
    private readonly List<ProductCategory> data = new();

    private ProductCategoryDaoMemory()
    {
    }

    public void Add(ProductCategory item)
    {
        item.Id = data.Count + 1;
        data.Add(item);
    }

    public void Remove(int id)
    {
        data.Remove(Get(id));
    }

    public ProductCategory Get(int id)
    {
        return data.Find(x => x.Id == id);
    }

    public IEnumerable<ProductCategory> GetAll()
    {
        return data;
    }

    public static ProductCategoryDaoMemory GetInstance()
    {
        if (instance == null) instance = new ProductCategoryDaoMemory();

        return instance;
    }
}
>>>>>>> r1remote/development
