using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Core
{
    public interface IBaseServices<TDtoAddModel, TDtoUpdateModel, TDtoRemove>
    {
        ServicesResult GetAll();

        ServicesResult GetById(int id);

        ServicesResult Save(TDtoAddModel dtoAdd);

        ServicesResult Update(TDtoUpdateModel dtoUpdate);

        ServicesResult Remove(TDtoRemove dtoRemove);






    }
}