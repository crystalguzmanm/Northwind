using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
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
        private readonly IConfiguration configuration;

        public SuppliersService1(ISuppliersRepository suppliersRepository,ILogger<SuppliersService1> logger,IConfiguration configuration)
        {
         
          this.suppliersRepository = suppliersRepository;   
          this.logger = logger;
          this.configuration = configuration;

        }

        // validaciones bases para ser reutilizadas por los metodos //
        private ServicesResult ValidateSuppliersCommon(SuppliersDtoBase dto)
        {
            ServicesResult result = new ServicesResult();

            // Validaciones de CompanyName
            if (string.IsNullOrEmpty(dto.CompanyName))
            {
                result.Message = this.configuration["MensajeValidaciones:CompanyNameRequerido"];
                result.Success = false;
                return result;
            }
            if (dto.CompanyName.Length > 100) // Actualiza este valor con la longitud máxima permitida
            {
                result.Message = this.configuration["MensajeValidaciones:CompanyNameLongitud"];
                result.Success = false;
                return result;
            }
            //Validaciones de ContactName//
            if (string.IsNullOrEmpty(dto.ContactName))
            {
                result.Message = this.configuration["MensajeValidacioness:ContactNameRequerido"];
                result.Success = false;
                return result;
            }
            if (dto.ContactName.Length > 100) // Actualiza este valor con la longitud máxima permitida
            {
                result.Message = this.configuration["MensajeValidacioness:ContactNameLogitud"];
                result.Success = false;
                return result;
            }
            //Validaciones de Country//
            if (string.IsNullOrEmpty(dto.Country))
            {
                result.Message = this.configuration["MensajeValidacioness:CountryRequerido"];
                result.Success = false;
                return result;
            }
            if (dto.Country.Length > 100) // Actualiza este valor con la longitud máxima permitida
            {
                result.Message = this.configuration["MensajeValidacioness:CountryLogitud"];
                result.Success = false;
                return result;
            }

            // Validaciones de ShipperID
            if (dto is ShippersDtoAdd && (dto as SuppliersDtoAdd).SuppliersID <= 0)
            {
                result.Message = this.configuration["MensajeValidaciones:ShipersIDRequerido"];
                result.Success = false;
                return result;
            }

            return result;
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
                this.suppliersRepository.Remove(suppliers);
                result.Message = this.configuration["MensajesSuppliersSuccess:RemoveSuccessMessage"];
                result.Data = suppliers;

            }  
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajesSuppliersSuccess:RemoveErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Save(SuppliersDtoAdd dtoAdd)
        {

            SuppliersResponse result = new SuppliersResponse();
            // validaciones reutilizadas //
            ServicesResult validation = ValidateSuppliersCommon(dtoAdd);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;
            }
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
                result.Message = this.configuration["MensajesSuppliersSuccess:AddSuccessMessage"];
                result.SuppliersId = suppliers.SupplierID;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajesSuppliersSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Update(SuppliersDtoUpdate dtoUpdate)
        {

            ServicesResult result = new ServicesResult();
            // validaciones reutilizadas //
            ServicesResult validation = ValidateSuppliersCommon(dtoUpdate);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;
            }
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
                result.Message = this.configuration["MensajesSuppliersSuccess:UpdateSuccessMessage"];
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajesSuppliersSuccess:UpdateErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }
    }
    
}
