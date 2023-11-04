using Northwind.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Response
{
    public class OrdersDetailsResponse : ServicesResult
    {
        public int OrderDetailsID { get; set; }
       
    }
}
