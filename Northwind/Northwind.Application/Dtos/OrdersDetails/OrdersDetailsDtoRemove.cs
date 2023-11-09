using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.OrdersDetails
{
    public class OrdersDetailsDtoRemove : OrdersDetailsDtoBase
    {
    
        public bool Deleted { get; set; }

    }
}
