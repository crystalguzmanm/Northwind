using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
using Northwind.Application.Dtos.Suppliers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Contracts
{
    public interface ISuppliersService : IBaseServices<SuppliersDtoAdd, SuppliersDtoUpdate, SuppliersDtoRemove>
    {
    


    }
}
