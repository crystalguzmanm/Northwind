using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Suppliers
{
    public class SuppliersDtoGetAll 
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string? ContactName { get; set; }

         public string? Country { get; set; }    

    }
}
