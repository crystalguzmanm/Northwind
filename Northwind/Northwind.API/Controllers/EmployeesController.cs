using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesRepository employeesRepository;
        public EmployeesController(EmployeesRepository employeesRepository)
        {
            this.employeesRepository.GetEmployees();
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            var employees =  this.employeesRepository.GetEmployees();
            return employees;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Employees Get(int id) 
        {
            return this.employeesRepository.GetEmployess(id);
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
