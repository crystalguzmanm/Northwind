using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface ISuppliersRepository
    {
       
            void Save(Suppliers suppliers);

            void Update(Suppliers suppliers);
            void Remove(Suppliers suppliers);
            List<Suppliers> GetSuppliers();
            Suppliers GetSuppliers(int Id);

            bool Exists(Expression<Func<Suppliers, bool>> filter);
        

    }
}
