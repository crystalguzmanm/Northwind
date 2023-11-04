using Northwind.Application.Core;
using Northwind.Application.Dtos.OrdersDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Contracts
{
    public interface IOrdersDetailsServices : IBaseServices<OrdersDetailsDtoAdd, OrdersDetailsDtoUpdate, OrdersDetailsDtoRemove>
    {
        object GetOrdersDetailsByOrderDetailsID(int ordersDetailsID);
    }


}