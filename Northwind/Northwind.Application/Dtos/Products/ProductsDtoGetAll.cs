

using System;

namespace Northwind.Application.Dtos.Products
{
    public class ProductsDtoGetAll
    {
        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }

        
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int? UserMod { get; set; }
        public DateTime CreationDate { get; set; }
        
        public int ProductID { get; set; }
    }
}