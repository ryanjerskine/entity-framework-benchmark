using BenchmarkDotNet.Attributes;
using EFvsNICORM.EFModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFvsNICORM
{
    public class EFvsNICORM
    {
        EFRepository _EFRepo;
        DapperRepository _DapperRepo;

        public EFvsNICORM()
        {
            _EFRepo = new EFRepository();
            _DapperRepo = new DapperRepository();
        }

        // Single Product
        [Benchmark]
        public Product GetProductWithEntityFramework() => _EFRepo.GetProduct(20);
        [Benchmark]
        public DapperModels.Product GetProductWithDapper() => _DapperRepo.GetProduct(20);

        // Multiple Products
        [Benchmark]
        public List<Product> GetProductsWithEntityFramework() => _EFRepo.GetProducts();
        [Benchmark]
        public List<Product> GetProductsWithEntityFrameworkNoTracking() => _EFRepo.GetProductsNoTracking();
        [Benchmark]
        public List<DapperModels.Product> GetProductsWithDapper() => _DapperRepo.GetProducts();

        // Multiple Ordered Products
        [Benchmark]
        public List<Product> GetProductsWithEntityFrameworkOrdered() => _EFRepo.GetProductsOrderBy();
        [Benchmark]
        public List<Product> GetProductsWithEntityFrameworkOrderedInSQL() => _EFRepo.GetProductsSQLOrderBy();
        [Benchmark]
        public List<DapperModels.Product> GetProductsWithDapperOrdered() => _DapperRepo.GetProductsOrderBy();
    }
}
