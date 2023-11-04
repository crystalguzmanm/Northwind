using Northwind.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Response
{
    public class OrdersResponse : ServicesResult
    {
        public int OrderID { get; set; }
    }
}
