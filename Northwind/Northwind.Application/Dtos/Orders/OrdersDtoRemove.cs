
using System;

namespace Northwind.Application.Dtos.Orders
{
    public class OrdersDtoRemove : DtoBase
    {
        public int OrderID { get; set; }
        public bool Deleted { get; set; }
    }
}
