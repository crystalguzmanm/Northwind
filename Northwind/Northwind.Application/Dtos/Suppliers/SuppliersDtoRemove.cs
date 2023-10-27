using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Suppliers
{
    public  class SuppliersDtoRemove : DtoBase
    {
        public int SuppliersID { get; set; }
        public bool Deleted { get; set; }

    }
}
