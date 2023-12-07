using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Products;

using Northwind.Application.Response;
using Northwind.Domain.Entities;
using System;
using Northwind.Infrastructure.Interfaces;

namespace Northwind.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        private readonly ILogger<ProductsService> logger;
        private readonly IConfiguration configuration;

        public ProductsService(IProductsRepository productsRepository,
                               ILogger<ProductsService> logger,
                               IConfiguration configuration)
        {
            this.productsRepository = productsRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServicesResult GetAll() //TODO GetAll
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result.Data = this.productsRepository.GetEntities();


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorProducts: GetErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult GetById(int Id) //TODO Solution
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result.Data = this.productsRepository.GetProductsBySupplierID(Id);

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorProducts: GetByIdErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }


        public object GetProductsByProductID(int productsID)//TODO Implementar 
        {
            throw new NotImplementedException();
        }

        public ServicesResult Remove(ProductsDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult();
            ServicesResult validation = ProductsValidaciones(dtoRemove);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;

            }
            try
            {
                Products products = new Products()
                {
                    ProductID = dtoRemove.ProductID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.DeletedDate,
                    UserDeleted = dtoRemove.ChangeUser
                };
                this.productsRepository.Remove(products);
                result.Message = "El producto ha sido removido";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ha ocurrido un error removiendo el producto";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult Save(ProductsDtoAdd dtoAdd)
        {
            ProductsResponse result = new ProductsResponse();

            ServicesResult validation = ProductsValidaciones(dtoAdd);
            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;

            }

            try
            {



                Products products = new Products()
                {
                    ProductID = dtoAdd.ProductID,
                    ProductName = dtoAdd.ProductName,
                    QuantityPerUnit = dtoAdd.QuantityPerUnit,
                    UnitPrice = dtoAdd.UnitPrice,
                    UnitsInStock = dtoAdd.UnitsInStock



                };

                this.productsRepository.Save(products);

                result.Message = this.configuration["MensajesProductsSuccess:AddSuccessMessage"];

                result.ProductID = products.ProductID;
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorProducts:AddErrorMessage"];

                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }

        public ServicesResult Update(ProductsDtoUpdate dtoUpdate)
        {
            ServicesResult result = new ServicesResult();
            ServicesResult validation = ProductsValidaciones(dtoUpdate);

            if (!validation.Success)
            {
                result.Message = validation.Message;
                result.Success = false;
                return result;

            }

            try
            {

                Products products = new Products()
                {
                    ProductID = dtoUpdate.ProductID,
                    ProductName = dtoUpdate.ProductName,
                    QuantityPerUnit = dtoUpdate.QuantityPerUnit,
                    UnitPrice = dtoUpdate.UnitPrice,
                    UnitsInStock = dtoUpdate.UnitsInStock



                };
                this.productsRepository.Update(products);

                result.Message = this.configuration["MensajesProductsSuccess:UpdateSuccessMessage"];


            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["MensajeProductError: UpdateErrorMessage"];

                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }


        // validaciones bases para ser reutilizadas por los metodos //
        private ServicesResult ProductsValidaciones(ProductsDtoBase dto)
        {
            ServicesResult result = new ServicesResult();

            // Validaciones de CompanyName
            
            if (dto.CreationUser <= 0)
            {
                result.Message = this.configuration["MensajeValidaciones: ProductUsuarioValor"];
                result.Success = false;
                return result;

            }

            return result;
        }


    }
}
