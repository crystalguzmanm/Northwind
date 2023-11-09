
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Orders;
using Northwind.Application.Dtos.OrdersDetails;

using Northwind.Application.Response;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Northwind.Application.Services
{
    public class OrdersDetailsService :IOrdersDetailsServices
    {
        private readonly IOrdersDetailsRepository ordersDetailsRepository;
        private readonly ILogger<OrdersDetailsService> logger;
        private readonly IConfiguration configuration;

        public OrdersDetailsService(IOrdersDetailsRepository ordersDetailsRepository,
                               ILogger<OrdersDetailsService> logger,
                               IConfiguration configuration)
        {
            this.ordersDetailsRepository = ordersDetailsRepository;
            this.logger = logger;
        }
        public ServicesResult GetAll()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var ordersDetails = this.ordersDetailsRepository.GetEntities()
                                                .Select(ordersDetails =>
                                                            new OrdersDetailsDtoGetAll()
                                                            {
                                                                OrderDetailsID = ordersDetails.OrderDetailsID,
                                                                ModifyDate = ordersDetails.ModifyDate,
                                                                CreationUser = ordersDetails.CreationUser,
                                                                ProductID = ordersDetails.ProductID,
                                                                Quantity = ordersDetails.Quantity,
                                                                UnitPrice = ordersDetails.UnitPrice,
                                                                Discount = ordersDetails.Discount


                                                            });
                result.Data = ordersDetails;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ha ocurrido un error obteniendo las ordenesDetails";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult GetById(int Id)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                var ordersDetails = this.ordersDetailsRepository.GetEntity(Id);

                OrdersDetailsDtoGetAll ordersDetailsModel = new OrdersDetailsDtoGetAll()
                {
                    OrderDetailsID = ordersDetails.OrderDetailsID,
                    ModifyDate = ordersDetails.ModifyDate,
                    CreationUser = ordersDetails.CreationUser,
                    ProductID = ordersDetails.ProductID,
                    Quantity = ordersDetails.Quantity,
                    UnitPrice = ordersDetails.UnitPrice,
                    Discount = ordersDetails.Discount



                };
                result.Data = ordersDetailsModel;

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ha ocurrido un error obteniendo la ordenDetails";
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }
     
        public object GetOrdersDetailsByOrderDetailsID(int ordersDetailsID)//TODO 
        {
            throw new NotImplementedException();
        }

        public ServicesResult Remove(OrdersDetailsDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                OrdersDetails ordersDetails = new OrdersDetails()
                {
                    OrderDetailsID = dtoRemove.OrderDetailsID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.DeletedDate,
                    UserDeleted = dtoRemove.ChangeUser
                    
                };
                this.ordersDetailsRepository.Remove(ordersDetails);
                result.Message = "La ordenDetails ha sido removida";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ha ocurrido un error removiendo la ordenDetails";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult Save(OrdersDetailsDtoAdd dtoAdd)
        {
            OrdersDetailsResponse result = new OrdersDetailsResponse();

            try
            {
     
                if (dtoAdd.CreationUser <= 0) 
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderUsuarioValor"];
                    result.Success = false;
                    return result;

                }

                if (dtoAdd.Discount < 0 || dtoAdd.Discount > 1)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderUsuarioValor"];
                    result.Success = false;
                    return result;


                }

                if (dtoAdd.Quantity <= 0)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderUsuarioValor"];
                    result.Success = false;
                    return result;

                }


                OrdersDetails ordersDetails = new OrdersDetails()
                {
                    CreationDate = dtoAdd.CreationDate,
                    CreationUser = dtoAdd.CreationUser,
                    Discount = dtoAdd.Discount,
                    ModifyDate = dtoAdd.ModifyDate,
                    Quantity = dtoAdd.Quantity



                };
                this.ordersDetailsRepository.Save(ordersDetails);

                result.Message = this.configuration["MensajesOrdersSuccess:AddSuccessMessage"];

                result.OrderDetailsID = ordersDetails.OrderDetailsID;
            }
           
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorOrders: AddErrorMessage"];

                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }

        public ServicesResult Update(OrdersDetailsDtoUpdate dtoUpdate)
        {
            OrdersDetailsResponse result = new OrdersDetailsResponse();

            try
            {
               
                if (dtoUpdate.CreationUser <= 0) 
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderNombreRequerido"];
                    result.Success = false;
                    return result;

                }

                if (dtoUpdate.Discount < 0 || dtoUpdate.Discount > 1)
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderNombreRequerido"];
                    result.Success = false;
                    return result;


                }

                if (dtoUpdate.Quantity <= 0) 
                {
                    result.Message = this.configuration["MensajeValidaciones: OrderNombreRequerido"];
                    result.Success = false;
                    return result;

                }


                OrdersDetails ordersDetails = new OrdersDetails()
                {
                   OrderDetailsID = dtoUpdate.OrderDetailsID,
                   ModifyDate = dtoUpdate.ModifyDate,
                   CreationUser = dtoUpdate.CreationUser,
                   Discount = dtoUpdate.Discount,
                   Quantity = dtoUpdate.Quantity

                };

                this.ordersDetailsRepository.Update(ordersDetails);

                result.Message = this.configuration["MensajesOrdersSuccess:AddSuccessMessage"];
                result.OrderDetailsID = ordersDetails.OrderDetailsID;
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorOrders: UpdateErrorMessage"];

                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }
    } 
}
