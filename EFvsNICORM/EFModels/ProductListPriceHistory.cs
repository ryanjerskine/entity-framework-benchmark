﻿using System;
using System.Collections.Generic;

namespace EFvsNICORM.EFModels
{
    public partial class ProductListPriceHistory
    {
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; }
    }
}
