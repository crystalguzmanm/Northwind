using Northwind.Application.Core;
using Northwind.Application.DTOs.Customers;


namespace Northwind.Application.Contracts
{
    public interface ICustomersService : IBaseServices<CustomersDtoAdd, CustomersDtoUpdate, CustomersDtoRemove>
    {
        ServiceResult Remove(CustomersDtoRemove dtoRemove);
    }
}
