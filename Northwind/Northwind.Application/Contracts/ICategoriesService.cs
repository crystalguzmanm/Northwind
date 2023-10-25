using Northwind.Application.Core;
using Northwind.Application.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Contracts
{
    public interface ICategproessService : IBaseServices<CategoriesDtoAdd, CategoriesDtoUpdate, CategoriesDtoRemove>
    {
        object GeCategoriesByCategoriesID(int categotiesId);


    }
}