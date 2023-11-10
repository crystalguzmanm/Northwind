using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Products
{
    public abstract class ProductsDtoBase : DtoBase
    {
        public int ProductID { get; set; }

        public DateTime ModifyDate { get; set; }
       
    }
}