using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Products
{
    public abstract class ProductsDtoBase : DtoBase
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }


    }
}