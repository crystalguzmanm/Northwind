
using System;

namespace Northwind.Application.Dtos.Products
{
    public class ProductsDtoRemove : ProductsDtoBase
    {

        public bool Deleted { get; set; }
        public int? ChangeUser { get; internal set; }
    }
}
