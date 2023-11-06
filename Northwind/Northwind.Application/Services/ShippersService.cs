
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
using Northwind.Application.Response;
using Northwind.Domain.Core;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Numerics;

namespace Northwind.Application.Services
{
    public class ShippersService : IShippersService
    {
        private readonly IShippersRepository shippersRepository;
        private readonly ILogger<ShippersService> logger;
        private readonly IConfiguration configuration;

        public ShippersService(IShippersRepository shippersRepository,ILogger<ShippersService>logger,IConfiguration configuration) 
        { 
          this.shippersRepository = shippersRepository; 
          this.logger = logger;   
          this.configuration = configuration;    
        } 
        
        
        // validaciones bases para ser reutilizadas por los metodos //
        private ServicesResult ValidateShippersCommon(ShippersDtoBase dto)
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

            // Validaciones de Phone
            if (string.IsNullOrEmpty(dto.Phone))
            {
                result.Message = this.configuration["MensajeValidaciones:PhoneRequerido"];
                result.Success = false;
                return result;
            }
            if (dto.Phone.Length > 20) // Actualiza este valor con la longitud máxima permitida
            {
                result.Message = this.configuration["MensajeValidaciones:PhoneLongitud"];
                result.Success = false;
                return result;
            }

            // Validaciones de ShipperID
            if (dto is ShippersDtoAdd && (dto as ShippersDtoAdd).ShipperID <= 0)
            {
                result.Message = this.configuration["MensajeValidaciones:ShipersIDRequerido"];
                result.Success = false;
                return result;
            }

            return result;
        }


        public ServicesResult GetAll()
        {
            ServicesResult result = new ServicesResult();
            
            try
            {
                var shippers = this.shippersRepository.GetEntities().Select(shippers => new ShippersDtoGetAll()
                {
                    CreationDate = shippers.CreationDate,
                    ModifyDate = shippers.ModifyDate,
                    Phone = shippers.Phone,
                    CompanyName = shippers.CompanyName,
                    Id = shippers.ShipperID
                    

                });

                result.Message = "Aqui estan todos los registros de la tabla shippers ";
                result.Data = shippers;

            }
            catch(Exception ex ) {

                result.Success = false;
                result.Message = $"Ocurrio  un error obteniendo los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());
               
            }
            return result;
        }

        public ServicesResult GetById(int id)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                var shippers = this.shippersRepository.GetEntity(id);
                ShippersDtoGetAll shipperModel = new ShippersDtoGetAll()
                { CompanyName = shippers.CompanyName, 
                   Phone =  shippers.Phone,
                   ModifyDate= shippers.ModifyDate, 
                   Id = shippers.ShipperID


                };
                result.Data = shippers;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error obteniendo los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public object GetShippersByShippersID(int shippersId)
        {
            throw new NotImplementedException();
        }

        public ServicesResult Remove(ShippersDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult();
            // validaciones reutilizadas //
            ServicesResult validation = ValidateShippersCommon(dtoRemove);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;
            }
            try
            {
                Shippers shippers = new Shippers()
                {
                    ShipperID = dtoRemove.ShipperID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,UserDeleted = dtoRemove.ChangeUser


                };
                this.shippersRepository.Remove(shippers);

                result.Message = this.configuration["MensajesShippersSuccess:RemoveSuccessMessage"];
                result.Data = shippers;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajesShippersSuccess:RemoveErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Save(ShippersDtoAdd dtoAdd)
        {
            ShippersResponse result = new ShippersResponse();
            // validaciones reutilizadas //
            ServicesResult validation = ValidateShippersCommon(dtoAdd);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;
            }
            try
            {  
                Shippers shippers = new Shippers()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,   
                    CompanyName = dtoAdd.CompanyName,
                    Phone = dtoAdd.Phone


                };

                this.shippersRepository.Save(shippers);
                result.Message = this.configuration["MensajesShippersSuccess:AddSuccessMessage"];
                result.ShippersId = shippers.ShipperID;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajeShippersSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Update(ShippersDtoUpdate dtoUpdate)
        {
            ShippersResponse result = new ShippersResponse();
            // validaciones reutilizadas //
            ServicesResult validation = ValidateShippersCommon(dtoUpdate);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;
            }
            try
            { 


                Shippers shippers = new Shippers()
                {
                    CreationDate = dtoUpdate.ChangeDate,
                    CreationUser = dtoUpdate.ChangeUser,
                    CompanyName = dtoUpdate.CompanyName,
                    Phone = dtoUpdate.Phone,
                    ModifyDate = dtoUpdate.ChangeDate,
                    UserMod = dtoUpdate.ChangeUser,
                    ShipperID = dtoUpdate.ShipperID
                };
               this.shippersRepository.Update(shippers);
               result.Message = this.configuration["MensajeShippersSuccess:UpdateSuccessMessage"];
               

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajeShippersSuccess:UpdateErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

       
    }

   
       
    
}
