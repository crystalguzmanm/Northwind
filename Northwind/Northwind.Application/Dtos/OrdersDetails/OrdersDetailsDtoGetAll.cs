using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.OrdersDetails
{
    public class OrdersDetailsDtoGetAll //TODO
    {
        public int OrderDetailsID { get; set; }
        public int ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public DateTime CreationDate { get; set; }

        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}

