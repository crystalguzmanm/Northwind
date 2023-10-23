using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Shippers
{
    public abstract  class ShippersDtoBase 
    {   public  int ShipperID { get; set; }
        public string? CompanyName { get; set; }

        public string? Phone { get; set; }

       public DateTime ChangeDate { get; set; }

        public int ChangeUser { get; set; }

        public DateTime ModifyDate{ get; set; }

    }
}
