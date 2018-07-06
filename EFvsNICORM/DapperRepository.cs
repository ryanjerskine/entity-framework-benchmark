using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EFvsNICORM.DapperModels;

namespace EFvsNICORM
{
    class DapperRepository
    {
        public Product GetProduct(int productId)
        {
            var query = @"
            SELECT *
            FROM [Production].[Product]
            WHERE ProductId = @productId";

            using (IDbConnection db = new SqlConnection(@"Server=DESKTOP-8PP3ALM;Database=AdventureWorks;Trusted_Connection=True;"))
            {
                return db.Query<DapperModels.Product>(query, new { productId }).FirstOrDefault();
            }
        }

        public List<Product> GetProducts()
        {
            var query = @"
            SELECT *
            FROM [Production].[Product]";

            using (IDbConnection db = new SqlConnection(@"Server=DESKTOP-8PP3ALM;Database=AdventureWorks;Trusted_Connection=True;"))
            {
                return db.Query<DapperModels.Product>(query).ToList();
            }
        }

        public List<Product> GetProductsBySubcategory(int subcategoryId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsOrderBy()
        {
            var query = @"
            SELECT *
            FROM [Production].[Product]
            ORDER BY ProductNumber";

            using (IDbConnection db = new SqlConnection(@"Server=DESKTOP-8PP3ALM;Database=AdventureWorks;Trusted_Connection=True;"))
            {
                return db.Query<DapperModels.Product>(query).ToList();
            }
        }
    }
}
