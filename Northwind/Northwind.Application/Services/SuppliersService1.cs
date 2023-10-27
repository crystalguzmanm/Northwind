using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Suppliers;
using Northwind.Application.Response;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application.Services
{
    public class SuppliersService1 : ISuppliersService
    {
        private readonly ISuppliersRepository suppliersRepository; 
        private readonly ILogger<SuppliersService1>logger;
        
        public SuppliersService1(ISuppliersRepository suppliersRepository,ILogger<SuppliersService1> logger)
        {
         
          this.suppliersRepository = suppliersRepository;   
          this.logger = logger;   
        
        }
        public ServicesResult GetAll()
        { ServicesResult result = new ServicesResult(); 
            try
            {
                var suppliers = this.suppliersRepository.GetEntities().Select(suppliers => new SuppliersDtoGetAll()
                { CompanyName = suppliers.CompanyName,
                  ContactName = suppliers.ContactName,
                  ModifyDate = suppliers.ModifyDate,
                  Country = suppliers.Country,  
                  CreationDate = suppliers.CreationDate,    
                  Id = suppliers.SupplierID

                });
                result.Data = suppliers; 
            }
            catch (Exception ex)
            {
                result.Success = false; 
                result.Message = $"ocurrio un error obteniendo a los registro de la tabla Suppliers";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult GetById(int id)
        {
            ServicesResult result = new ServicesResult();

            try
            { 
                var suppliers =  this.suppliersRepository.GetEntity(id);
                SuppliersDtoGetAll suppliersModel = new SuppliersDtoGetAll()
                {
                    CompanyName = suppliers.CompanyName,
                    ContactName = suppliers.ContactName,
                    ModifyDate = suppliers.ModifyDate,  
                    Country = suppliers.Country,    
                    CreationDate = suppliers.CreationDate,  
                     Id = suppliers.SupplierID  

                };
                result.Data = suppliers;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error obteniendo la id  de la tabla Suppliers  ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Remove(SuppliersDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                Suppliers suppliers = new Suppliers()
                {
                     SupplierID = dtoRemove.SuppliersID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    UserDeleted = dtoRemove.ChangeUser


                };
               

                result.Message = "El registro fue removido exitosamente";
                result.Data = suppliers;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error removiendo  los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Save(SuppliersDtoAdd dtoAdd)
        {

            SuppliersResponse result = new SuppliersResponse();

            try
            {
                Suppliers suppliers = new Suppliers()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,
                    CompanyName = dtoAdd.CompanyName,
                    ContactName = dtoAdd.ContactName,
                    Country= dtoAdd.Country,

                   


                };

                this.suppliersRepository.Save(suppliers);

                result.Message = "El registro  fue creado exitosamente";
                result.SuppliersId = suppliers.SupplierID;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error Guardando los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Update(SuppliersDtoUpdate dtoUpdate)
        {

            ServicesResult result = new ServicesResult();

            try
            {
                Suppliers suppliers = new Suppliers()
                {
                    CreationDate = dtoUpdate.ChangeDate,
                    CreationUser = dtoUpdate.ChangeUser,
                    CompanyName = dtoUpdate.CompanyName,
                    ModifyDate = dtoUpdate.ChangeDate,
                    UserMod = dtoUpdate.ChangeUser,
                    SupplierID = dtoUpdate.SuppliersID

                };
                this.suppliersRepository.Update(suppliers);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error  actualizando  los registros ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }
    }
    
}
