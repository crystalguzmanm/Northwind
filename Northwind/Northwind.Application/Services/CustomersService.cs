using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.DTOs.Customers;
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

        public CustomersService(ICustomersRepository customersRepository, 
                                                       ILogger<CustomersService> logger)
        {
            this.customersRepository = customersRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var Customers = this.customersRepository.GetEntities().Select(Customers => new CustomersDtoGetAll()
                {
                    CompanyName = Customers.CompanyName,
                    City = Customers.City,
                    Phone = Customers.Phone,
                    Address = Customers.Address

                }).ToList();

                result.Data = Customers;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo los estudiantes";
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
                var Customers = this.customersRepository.GetEntity(id);
                CustomersDtoGetAll CustomersModel = new CustomersDtoGetAll()
                {
                    CompanyName = Customers.CompanyName,
                    City = Customers.City,
                    Phone = Customers.Phone,
                    Address = Customers.Address


                };
                result.Data = CustomersModel;
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
                { ID = dtoRemove.ID,
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
                Customers customers = new Customers()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,
                    CompanyName = dtoAdd.CompanyName,
                    Phone = dtoAdd.Phone,

                }; 
                this.customersRepository.Save(customers);

                result.Message = "El customer fue creado correctamente";
                result.CustomerID = Customers.CustomerID; //TODO problema con el Customer ID
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio  un error guardando el Customer ";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(CustomersDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult(); 
            try
            {
                Customers customers = new Customers()
                {
                    ModifyDate = dtoUpdate.ModifyDate,
                    CompanyName = dtoUpdate.CompanyName,
                    Phone = dtoUpdate.Phone,
                    ContactName = dtoUpdate.ContactName
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
