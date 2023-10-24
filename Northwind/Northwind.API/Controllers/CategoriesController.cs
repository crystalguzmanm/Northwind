using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
//using Northwind.Domain.Repository;
using Northwind.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            var categories = this.categoriesRepository.GetCategories();
            return (IEnumerable<Categories>)categories;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
