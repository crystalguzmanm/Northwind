using Northwind.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Response
{
    public class ProductsResponse : ServicesResult
    {
        public int ProductID { get; set; }
    }
}