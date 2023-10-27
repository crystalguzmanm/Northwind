﻿

using System;

namespace Northwind.Application.Dtos.Orders
{
    public class OrdersDtoGetAll
    {
        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string? ShipName { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public int? UserMod { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ShipCity { get; set; }
        public int OrderID { get; set; }
    }
}
