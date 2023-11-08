using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.DTOs.Customers;
using Northwind.Application.Exceptions;
using Northwind.Application.Responses;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Xml;

namespace Northwind.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly ILogger<CustomersService> logger;
        private readonly IConfiguration configuration;

        public CustomersService(ICustomersRepository customersRepository, 
                                                       ILogger<CustomersService> logger, 
                                                       IConfiguration configuration)
        {
            this.customersRepository = customersRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var customers = this.customersRepository.GetEntities().Select(customers => new CustomersDtoGetAll()
                {
                    CompanyName = customers.CompanyName,
                    City = customers.City,
                    Phone = customers.Phone,
                    Address = customers.Address,
                    CustomerID = customers.CustomerID
                    

                }).ToList();

                result.Data = customers;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo los Customers";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private ServiceResult Ok(object customers)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var customers = this.customersRepository.GetEntity(id);
                CustomersDtoGetAll customersModel = new CustomersDtoGetAll()
                {
                    CompanyName = customers.CompanyName,
                    City = customers.City,
                    Phone = customers.Phone,
                    ModifyDate = customers.ModifyDate,
                    CreationUser = customers.CreationUser,
                    CustomerID = customers.CustomerID


                };
                result.Data = customersModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error obteniendo los datos del Customer";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Remove(CustomersDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            { //TODO problema con ID en el Remove
                Customers customers = new Customers()
                { CustomerID = dtoRemove.CustomerID,
                    Deleted = dtoRemove.Deleted, 
                    DeletedDate = dtoRemove.ChangeDate,
                    UserDeleted = dtoRemove.ChangeUser
                };
                this.customersRepository.Remove(customers);

                result.Message = "El customer fue removido";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio  un error removiendo el Customer ";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(CustomersDtoAdd dtoAdd)
        {
           // ServiceResult result = new ServiceResult();
            CustomerResponse result = new CustomerResponse();

            try
            {

                if (string.IsNullOrEmpty(dtoAdd.CompanyName))
                {
                    result.Message = this.configuration["MensajeValidaciones: customerCompanyRequerido"];
                    result.Success = false;
                    return result;  
                }

                if(dtoAdd.CompanyName.Length > 30)
                {
                    result.Message = this.configuration["MensajeValidaciones: customerCompanyLongitud"];
                    result.Success = false; 
                    return result;
                }

        
                Customers customers = new Customers()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,
                    CompanyName = dtoAdd.CompanyName,
                    Phone = dtoAdd.Phone,
                    ModifyDate = dtoAdd.ModifyDate

                }; 
                this.customersRepository.Save(customers);

                result.Message = this.configuration["MensajeCustomerSucess: AddSuccessMessage"];
                result.CustomerID = customers.CustomerID; 
            }
            catch (CustomerServiceException ssex)
            {
                result.Success = false;
                result.Message = ssex.Message;
                this.logger.LogError(result.Message, ssex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["MensajeCustomerSucess: AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(CustomersDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult(); 
            try
            {
                if (string.IsNullOrEmpty(dtoUpdate.CompanyName))
                {
                    result.Message = this.configuration["MensajeValidaciones: customerCompanyRequerido"];
                    result.Success = false;
                    return result;
                }

                if (dtoUpdate.CompanyName.Length > 30)
                {
                    result.Message = this.configuration["MensajeValidaciones: customerCompanyLongitud"];
                    result.Success = false;
                    return result;
                }

                Customers customers = new Customers()
                {
                    ModifyDate = dtoUpdate.ModifyDate,
                    CompanyName = dtoUpdate.CompanyName,
                    Phone = dtoUpdate.Phone,
                    ContactName = dtoUpdate.ContactName,
                    CustomerID = dtoUpdate.CustomerID
                };

                this.customersRepository.Update(customers);
                result.Message = "El Customer fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio  un error actualizando el Customer ";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
