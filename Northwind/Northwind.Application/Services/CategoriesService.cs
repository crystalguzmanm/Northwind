using Microsoft.Extensions.Logging;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Categories;
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
    public class CategoriesService
    {
        private readonly ICategoriesRepository categoriresRepository;
        private readonly ILogger<CategoriesService> logger;
        private readonly object categoriesRepository;

        public CategoriesService(ICategoriesRepository shippersRepository, ILogger<CategoriesService> logger)
        {
            this.categoriresRepository = shippersRepository;
            this.logger = logger;

        }



        public ServicesResult GetAll()
        {
            ServicesResult result = new ServicesResult();

            try
            {
                var categories = this.categoriesRepository.GetEntities().Select(categories => new CategoriesDtoGetAll()
                {
                    CategoryId = categories.CategoryId,
                    CategoryName = categories.CategoryName,
                    Description = categories.Description,
                    Picture = categories.Picture,

                });

                result.Data = categories;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo los datos de la tabla Categories ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult GetById(int id)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                var categories = this.categoriesRepository.GetEntity(id);
                {


                    //EN PROCESO//



                }

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error obteniendo los datos de la tabla Shippers ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public object GetCategoriesByCategoriesID(int CategoriresId)
        {
            throw new NotImplementedException();
        }

        public ServicesResult Remove(CategoriesDtoRemove dtoRemove)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                Categories categories = new Categories()
                {
                    CategoryId = dtoRemove.CategoryID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    UserDeleted = dtoRemove.ChangeUser


                };
                this.categoriesRepository.Remove(categories);

                result.Message = "La Categories fue removido exitosamente";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error removiendo  los datos de la tabla Categories ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Save(CategoriesDtoAdd dtoAdd)
        {
            CategoriesResponse result = new CategoriesResponse();

            try
            {
                Categories categories = new Categories()
                {
                    CategoryId = dtoAdd.CategoryId,
                    CategoryName = dtoAdd.CategoryName,
                    Description = dtoAdd.Description,
                    Picture = dtoAdd.Picture


                };

                this.categoriesRepository.Save(categories);

                result.Message = "El Shippers fue creado exitosamente";
                result.CategoriesId = categories.CategoryId;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error Guardando los datos de la tabla Categories ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServicesResult Update(CategoriesDtoUpdate dtoUpdate)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                Categories categories = new Categories()
                {
                    CategoryId = dtoUpdate.CategoryId,
                    CategoryName = dtoUpdate.CategoryName,
                    Description = dtoUpdate.Description,
                    Picture = dtoUpdate.Picture,

                };
                this.categoriesRepository.Update(categories);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrio  un error  actualizando  los datos de la tabla Categories ";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

    }
}
}
