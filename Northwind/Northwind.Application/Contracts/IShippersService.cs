using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Contracts
{
    public interface IShippersService : IBaseServices<ShippersDtoAdd, ShippersDtoUpdate, ShippersDtoRemove>
    {
        object GetShippersByShippersID(int shippersId);


    }
}
