using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;

namespace Northwind.Application.Validaciones
{
    public static  class ShippersValidation
    {
        public  static void CommonValidation (DateTime CreationDate,DateTime ModifyDate , string Phone , int ShipperID , string CompanyName, IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(CompanyName))
            {
                string ErrorMessage = $"{configuration["MensajeValidaciones: CompanyNameRequerido"]}";
                throw new Exception (ErrorMessage); 
            }
        }
    }
}
