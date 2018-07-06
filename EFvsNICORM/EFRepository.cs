using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFvsNICORM
{
    public class EFRepository
    {
        /// <summary>
        /// Get a product using the database id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Models.Product GetProduct (int productId)
        {
            using (var db = new Models.AdventureWorksContext())
            {
                var product = db.Product
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefault();
                return product;
            }
        }
        /// <summary>
        /// Get all of the products.
        /// </summary>
        /// <returns></returns>
        public List<Models.Product> GetProducts()
        {
            using (var db = new Models.AdventureWorksContext())
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
        public List<Models.Product> GetProductsNoTracking()
        {
            using (var db = new Models.AdventureWorksContext())
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
        public List<Models.Product> GetProductsOrderBy()
        {
            using (var db = new Models.AdventureWorksContext())
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
        public List<Models.Product> GetProductsSQLOrderBy()
        {
            using (var db = new Models.AdventureWorksContext())
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
        public List<Models.Product> GetProductsBySubcategory(int subcategoryId)
        {
            using (var db = new Models.AdventureWorksContext())
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
