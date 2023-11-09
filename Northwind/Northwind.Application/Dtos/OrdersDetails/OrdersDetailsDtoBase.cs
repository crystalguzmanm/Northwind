using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.OrdersDetails
{
    public abstract class OrdersDetailsDtoBase : DtoBase
    {
        public int OrderDetailsID { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public DateTime? ModifyDate { get; set; }
        //public int CreationUser { get; set; }
    }
}
