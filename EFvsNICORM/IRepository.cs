using System.Collections.Generic;
using EFvsNICORM.EFModels;

namespace EFvsNICORM
{
    public interface IRepository
    {
        Product GetProduct(int productId);
        List<Product> GetProducts();
        List<Product> GetProductsBySubcategory(int subcategoryId);
        List<Product> GetProductsNoTracking();
        List<Product> GetProductsOrderBy();
        List<Product> GetProductsSQLOrderBy();
    }
}