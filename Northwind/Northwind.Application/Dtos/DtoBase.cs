using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }

        public DateTime ChangeDate { get; set; }

    }
}