using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services;

public class ProductService
{
    private readonly IProductCategoryDao productCategoryDao;
    private readonly IProductDao productDao;

    public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao)
    {
        this.productDao = productDao;
        this.productCategoryDao = productCategoryDao;
    }

    public ProductCategory GetProductCategory(int categoryId)
    {
        return productCategoryDao.Get(categoryId);
    }

    public IEnumerable<Product> GetProductsForCategory(int categoryId)
    {
        var category = productCategoryDao.Get(categoryId);
        return productDao.GetBy(category);
    }
}