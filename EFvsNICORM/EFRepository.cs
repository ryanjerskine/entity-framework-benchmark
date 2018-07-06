using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFvsNICORM
{
    public class EFRepository : IRepository
    {
        /// <summary>
        /// Get a product using the database id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public EFModels.Product GetProduct (int productId)
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var product = db.Product
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefault();
                return product;
            }
        }
        /// <summary>
        /// Get a product using the database id without EF tracking.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public EFModels.Product GetProductNoTracking(int productId)
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var product = db.Product
                    .Where(p => p.ProductId == productId)
                    .AsNoTracking()
                    .FirstOrDefault();
                return product;
            }
        }
        /// <summary>
        /// Get all of the products.
        /// </summary>
        /// <returns></returns>
        public List<EFModels.Product> GetProducts()
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var products = db.Product
                    .ToList();
                return products;
            }
        }
        /// <summary>
        /// Get all of the products without EF tracking.
        /// </summary>
        /// <returns></returns>
        public List<EFModels.Product> GetProductsNoTracking()
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var products = db.Product
                    .AsNoTracking()
                    .ToList();
                return products;
            }
        }
        /// <summary>
        /// Get all of the products without EF tracking and sorted in code.
        /// </summary>
        /// <returns></returns>
        public List<EFModels.Product> GetProductsOrderBy()
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var products = db.Product
                    .AsNoTracking()
                    .ToList()
                    .OrderBy(p => p.ProductId)
                    .ToList();
                return products;
            }
        }
        /// <summary>
        /// Get all of the products without EF tracking and sorted in SQL.
        /// </summary>
        /// <returns></returns>
        public List<EFModels.Product> GetProductsSQLOrderBy()
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var products = db.Product
                    .OrderBy(p => p.ProductId)
                    .AsNoTracking()
                    .ToList();
                return products;
            }
        }
        /// <summary>
        /// Get all of the products that match the subcategory id.
        /// </summary>
        /// <param name="subcategoryId"></param>
        /// <returns></returns>
        public List<EFModels.Product> GetProductsBySubcategory(int subcategoryId)
        {
            using (var db = new EFModels.AdventureWorksContext())
            {
                var products = db.Product
                    .Where(b => b.ProductSubcategoryId == subcategoryId)
                    .OrderBy(b => b.ProductNumber)
                    .Include(p => p.ProductSubcategory)
                    .ToList();
                return products;
            }
        }
    }
}
