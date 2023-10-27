using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Suppliers
{
    public abstract class SuppliersDtoBase
    {
        public int SuppliersID { get; set; }

        public string? CompanyName { get; set; }

        public DateTime ChangeDate { get; set; }

        public int ChangeUser { get; set; }

        public DateTime ModifyDate { get; set; }

        public int ModifyUser { get; set; }

        public string? ContactName { get; set; }

        public string? Country { get; set; }



    }
}
