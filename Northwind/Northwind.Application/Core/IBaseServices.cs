using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Core
{
    public interface IBaseServices<TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        ServicesResult GetAll();
        ServicesResult GetById(int id);
        ServicesResult Save(TDtoAdd dtoAdd);
        ServicesResult Update(TDtoUpdate dtoUpdate);
        ServicesResult Remove(TDtoRemove dtoRemove);
    }
}