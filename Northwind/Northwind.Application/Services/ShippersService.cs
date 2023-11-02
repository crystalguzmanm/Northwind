
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
            try
            {
                Shippers shippers = new Shippers()
                {
                    ShipperID = dtoRemove.ShipperID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,UserDeleted = dtoRemove.ChangeUser


                };
                this.shippersRepository.Remove(shippers);

                result.Message = "El Shippers fue removido exitosamente";
                result.Data = shippers;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error removiendo  los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Save(ShippersDtoAdd dtoAdd)
        {
           
            ShippersResponse result = new ShippersResponse();

            try
            {  //Validaciones //
                if (string.IsNullOrEmpty(dtoAdd.CompanyName))
                {
                    result.Message = " El nombre de la empresa es requerido";
                    result.Success = false;
                    return result;
                }
                //Validaciones//

                if  (dtoAdd.CompanyName.Length > 0)
                {
                    result.Message = " La longitud del  campo CompanyName debe ser de 50  caracteres";
                    result.Success = false;
                    return result;
                }
                Shippers shippers = new Shippers()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,   
                    CompanyName = dtoAdd.CompanyName,
                    Phone = dtoAdd.Phone


                };

                this.shippersRepository.Save(shippers);

                result.Message = "El Shippers fue creado exitosamente";
                result.ShippersId = shippers.ShipperID;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error Guardando los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Update(ShippersDtoUpdate dtoUpdate)
        {
            ServicesResult result = new ServicesResult();

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
                    ShipperID = dtoUpdate.ShippersID

                };
               this.shippersRepository.Update(shippers);    
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error  actualizando  los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

    }

   
       
    
}
