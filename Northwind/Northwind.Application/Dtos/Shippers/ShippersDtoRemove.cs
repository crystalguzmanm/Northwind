using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Shippers
{
    public class ShippersDtoRemove : DtoBase 
    {
        public int ShipperID { get; set; }
        public bool Deleted { get; set; }



    }
}
