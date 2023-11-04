using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.OrdersDetails
{
    public class OrdersDetailsDtoRemove : DtoBase
    {
        public int OrderDetailsID { get; set; }
        public bool Deleted { get; set; }
    }
}
