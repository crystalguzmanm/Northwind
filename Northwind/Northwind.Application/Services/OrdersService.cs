
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
        public ServicesResult GetAll()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var orders = this.ordersRepository.GetEntities()
                                                .Select(orders => 
                                                            new OrdersDtoGetAll()
                                                            {
                                                                    CustomerID = orders.CustomerID,
                                                                    ModifyDate = orders.ModifyDate,
                                                                    CreationUser = orders.CreationUser,
                                                                    EmployeeID = orders.EmployeeID,
                                                                    ShipName = orders.ShipName
                                                                    
                                                            });
                result.Data = orders;

            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = this.configuration["MensajeOrderError: GetErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult GetById(int Id)
        {
            ServicesResult result = new ServicesResult() ;  

            try
            {
                var orders = this.ordersRepository.GetEntity(Id);

                OrdersDtoGetAll ordersModel = new OrdersDtoGetAll()
                {
                    CustomerID = orders.CustomerID,
                    ModifyDate = orders.ModifyDate,
                    CreationUser = orders.CreationUser,
                    EmployeeID = orders.EmployeeID,
                    ShipName = orders.ShipName,
                    OrderID = orders.OrderID


                };
                result.Data = ordersModel;

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["MensajeOrderError: GetByIdErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }
     

        public object GetOrdersByOrderID(int ordersID)//TODO 
        {
            throw new NotImplementedException();
        }

        public ServicesResult Remove(OrdersDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult() ;
            try
            {
                Orders orders = new Orders()
                {
                    OrderID = dtoRemove.OrderID,
                    Deleted = dtoRemove.Deleted, 
                    DeletedDate = dtoRemove.ChangeDate,
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

            try
            {
                 
                if (string.IsNullOrEmpty(dtoAdd.ShipName))
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipNameRequerido"];
                    result.Success = false;
                    return result;

                }

                if (dtoAdd.ShipName.Length > 40) 
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipCityRequerido"];
                    result.Success = false;
                    return result;

                }
                if (string.IsNullOrEmpty(dtoAdd.ShipCity))
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderCiudadRequerido"];
                    result.Success = false;
                    return result;

                }

                if (dtoAdd.ShipCity.Length > 15)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipCityLongitud"];
                    result.Success = false;
                    return result;


                }
                if (dtoAdd.CreationUser <= 0) 
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderUsuarioValor"];
                    result.Success = false;
                    return result;

                }

                Orders orders = new Orders() 
                {
                    CreationDate = dtoAdd.ChangeDate,
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
            try
            {
               
                if (string.IsNullOrEmpty(dtoUpdate.ShipName))
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderNombreRequerido"];
                    result.Success = false;
                    return result;

                }

                if (dtoUpdate.ShipName.Length > 40)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipNameLongitud"];
                    result.Success = false;
                    return result;

                }
                if (string.IsNullOrEmpty(dtoUpdate.ShipCity))
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipCityRequerido"];
                    result.Success = false;
                    return result;

                }
                if (dtoUpdate.ShipCity.Length > 15)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipCityLongitud"];
                    result.Success = false;
                    return result;


                }
                if (!dtoUpdate.OrderDate.HasValue)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderShipNameRequerido"];
                    result.Success = false;
                    return result;

                }

                Orders orders = new Orders()
                {
                    OrderID = dtoUpdate.OrderID,
                    CreationDate = dtoUpdate.ChangeDate,
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
    }
}
