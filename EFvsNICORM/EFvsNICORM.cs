using BenchmarkDotNet.Attributes;
using EFvsNICORM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFvsNICORM
{
    public class EFvsNICORM
    {
        EFRepository _EFRepo;

        public EFvsNICORM()
        {
            _EFRepo = new EFRepository();
        }

        [Benchmark]
        public Product GetProductWithEntityFramework() => _EFRepo.GetProduct(20);

        [Benchmark]
        public List<Product> GetProductsWithEntityFramework() => _EFRepo.GetProducts();

        [Benchmark]
        public List<Product> GetProductsWithEntityFrameworkNoTracking() => _EFRepo.GetProductsNoTracking();

        [Benchmark]
        public List<Product> GetProductsWithEntityFrameworkOrdered() => _EFRepo.GetProductsOrderBy();

        [Benchmark]
        public List<Product> GetProductsWithEntityFrameworkOrderedInSQL() => _EFRepo.GetProductsSQLOrderBy();
    }
}
