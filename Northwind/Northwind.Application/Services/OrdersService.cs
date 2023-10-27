
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Orders;
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

        public OrdersService(IOrdersRepository ordersRepository, 
                               ILogger<OrdersService> logger) 
        {
            this.ordersRepository = ordersRepository;
            this.logger = logger;
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
                result.Message = $"Ha ocurrido un error obteniendo las ordenes";
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
                result.Message = $"Ha ocurrido un error obteniendo la orden";
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }
        //Cuando hago el GetByOrdersId me da : : 'The method or operation is not implemented.'

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
            ServicesResult result = new ServicesResult() ;

            try
            {
                Orders orders = new Orders() 
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,
                    ShipName = dtoAdd.ShipName,
                    ShipCity = dtoAdd.ShipCity,
                    ModifyDate = dtoAdd.ModifyDate
                   


                };
                this.ordersRepository.Save(orders);
                result.Message = "La Orden fue creada correctamente.";
                  
                result.OrderID = orders.OrderID;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ha ocurrido un error guardando la orden";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult Update(OrdersDtoUpdate dtoUpdate)
        {
            ServicesResult result= new ServicesResult() ;
            try
            {
                Orders orders = new Orders()
                {
                    CreationDate = dtoUpdate.ChangeDate,
                    CreationUser = dtoUpdate.ChangeUser,
                    ShipName = dtoUpdate.ShipName,
                    ShipCity = dtoUpdate.ShipCity,
                    ModifyDate = dtoUpdate.ModifyDate,
                    OrderID = dtoUpdate.OrderId
                   
                };

                this.ordersRepository.Update(orders);
                result.Message = "La Orden fue actualizada correctamente";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ha ocurrido un error actualizando la orden";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
