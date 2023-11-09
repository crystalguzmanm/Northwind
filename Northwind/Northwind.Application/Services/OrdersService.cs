
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Orders;

using Northwind.Application.Response;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Northwind.Application.Services
{
    public class OrdersService : IOrdersServices
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly ILogger<OrdersService> logger;
        private readonly IConfiguration configuration;

        public OrdersService(IOrdersRepository ordersRepository, 
                               ILogger<OrdersService> logger,
                               IConfiguration configuration) 
        {
            this.ordersRepository = ordersRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServicesResult GetAll() //TODO GetAll
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result.Data = this.ordersRepository.GetAllOrders();
                

            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = this.configuration["ErrorOrders: GetErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult GetById(int Id) //TODO Solution
        {
            ServicesResult result = new ServicesResult() ;  

            try
            {
                result.Data = this.ordersRepository.GetOrderEmployee(Id);

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorOrders: GetByIdErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }
     

        public object GetOrdersByOrderID(int ordersID)//TODO Implementar 
        {
            throw new NotImplementedException();
        }

        public ServicesResult Remove(OrdersDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult();
            ServicesResult validation = OrdersValidaciones(dtoRemove);
            if (!validation.Success) 
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;
            
            }
            try
            {
                Orders orders = new Orders()
                {
                    OrderID = dtoRemove.OrderID, 
                    Deleted = dtoRemove.Deleted, 
                    DeletedDate = dtoRemove.DeletedDate,
                    UserDeleted = dtoRemove.ChangeUser
                } ;
                this.ordersRepository.Remove(orders);
                result.Message = "La orden ha sido removida";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ha ocurrido un error removiendo la orden";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult Save(OrdersDtoAdd dtoAdd)
        {
            OrdersResponse result = new OrdersResponse() ;
            
            ServicesResult validation = OrdersValidaciones(dtoAdd);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;

            }
            
            try
            {
                 
               

                Orders orders = new Orders() 
                {
                    CreationDate = dtoAdd.CreationDate,
                   CreationUser = dtoAdd.CreationUser,
                    ShipName = dtoAdd.ShipName,
                    ShipCity = dtoAdd.ShipCity,
                    ModifyDate = dtoAdd.ModifyDate
                   


                };

                this.ordersRepository.Save(orders);

                result.Message = this.configuration["MensajesOrdersSuccess:AddSuccessMessage"];

                result.OrderID = orders.OrderID ;
            }
           
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = this.configuration["ErrorOrders:AddErrorMessage"];

                this.logger.LogError(result.Message, ex.ToString());
            
            }

            return result;
        }

        public ServicesResult Update(OrdersDtoUpdate dtoUpdate)
        {
            ServicesResult result= new ServicesResult() ;
            ServicesResult validation = OrdersValidaciones(dtoUpdate);

            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;

            }

            try
            {

                Orders orders = new Orders()
                {
                    OrderID = dtoUpdate.OrderID,
                    CreationDate = dtoUpdate.CreationDate,
                    CreationUser = dtoUpdate.ChangeUser,
                    ShipName = dtoUpdate.ShipName,
                    ShipCity = dtoUpdate.ShipCity,
                    ModifyDate = dtoUpdate.ModifyDate



                };
                this.ordersRepository.Update(orders);

                result.Message = this.configuration["MensajesOrdersSuccess:UpdateSuccessMessage"];

               
            }
           
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["MensajeOrderError: UpdateErrorMessage"];

                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }


        // validaciones bases para ser reutilizadas por los metodos //
        private ServicesResult OrdersValidaciones(OrdersDtoBase dto) 
        {
            ServicesResult result = new ServicesResult();

            // Validaciones de CompanyName
                if (string.IsNullOrEmpty(dto.ShipName))
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderNombreRequerido"];
                    result.Success = false;
                    return result;

                }

                if (dto.ShipName.Length > 40)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipNameLongitud"];
                    result.Success = false;
                    return result;

                }
                if (string.IsNullOrEmpty(dto.ShipCity))
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipCityRequerido"];
                    result.Success = false;
                    return result;

                }
                if (dto.ShipCity.Length > 15)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipCityLongitud"];
                    result.Success = false;
                    return result;


                }
                if (!dto.OrderDate.HasValue)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipNameRequerido"];
                    result.Success = false;
                    return result;

                }
                if (dto.CreationUser <= 0)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderUsuarioValor"];
                    result.Success = false;
                    return result;

                }

            return result;
        }

     
    }
}
