using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.CategoriesAddModel;
using Northwind.API.Models.Modules.CategoriesGetAllModel;
using Northwind.API.Models.Modules.CategoriesUpdateModel;
using Northwind.Application.Contracts;
using Northwind.Application.Dtos.Categories;
using Northwind.Application.Dtos.Categories;
using Northwind.Application.Services;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoriesontroller : ControllerBase
    {
        private readonly CategoriesService categoryService;

        public Categoriesontroller(CategoriesService categoriesService)
        {
            this.categoryService = categoriesService;
        }


        [HttpGet("GetCategoriesByCategoriesID")]
        public IActionResult GetCategoriesByCategoriesID(int CategoriesId)
        {
            var categories = this.categoryService.GetCategoriesByCategoriesID(CategoriesId);
            return Ok(categories);
        }

        // GET: api/<CategoriresController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.categoryService.GetAll();

            if (!result.Success)
            {
                return BadRequest();
            }


            return Ok(result);


        }



        // GET api/<CategoriesController>/5
        [HttpGet("Getcategories")]
        public IActionResult Getcategories(int Id)
        {
            var result = this.categoryService.GetById(Id);

            if (!result.Success)
            {
                return BadRequest();
            }


            return Ok(result);

        }



        [HttpPost("SaveCategories")]
        public IActionResult Post([FromBody] CategoriesDtoAdd shippersAdd)
        {
            var result = this.categoryService.Save(categoriesAdd);


            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok();
        }


        // PUT api/<CategoriesController>/5


        [HttpPut("Updatecategories")]
        public IActionResult Put([FromBody] CategoriesDtoUpdate categoriesDtoUpdate)
        {
            var result = this.categoryService.Update(categoriesDtoUpdate);

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}