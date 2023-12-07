namespace Northwind.API.Models.Core
{
    public class ProductsBaseModel
    {
        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

    }
}
