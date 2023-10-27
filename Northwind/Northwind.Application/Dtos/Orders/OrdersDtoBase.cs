using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Orders
{
    public abstract class OrdersDtoBase : DtoBase
    {
        public int OrderId { get; set; }
        
        public DateTime ModifyDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCity { get; set; }
    }
}
