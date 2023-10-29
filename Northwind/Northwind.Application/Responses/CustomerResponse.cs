using Northwind.Application.Core;


namespace Northwind.Application.Responses
{
    public class CustomerResponse : ServiceResult
    {
        public int CustomerID { get; set; }
    }
}
