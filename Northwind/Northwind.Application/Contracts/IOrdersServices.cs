using Northwind.Application.Core;
using Northwind.Application.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Contracts
{
    public interface IOrdersServices : IBaseServices<OrdersDtoAdd, OrdersDtoUpdate, OrdersDtoRemove>
    {
        object GetOrdersByOrderID(int ordersID);
    }
}
