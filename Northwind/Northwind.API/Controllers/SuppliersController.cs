using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models.Modules.Shippers;
using Northwind.API.Models.Modules.Suppliers;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersRepository suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            this.suppliersRepository = suppliersRepository;
        }

       

        // GET: api/<SuppliersController>
        [HttpGet]
        public IActionResult Get()
        {
            var suppliers = this.suppliersRepository.GetEntities().Select(suppliers => new GetSuppliersModel()
            {
                CreationDate = suppliers.CreationDate,
                ModifyDate = suppliers.ModifyDate,
                ContactName = suppliers.ContactName,
                CompanyName = suppliers.CompanyName

            });

            return Ok(suppliers);


        }


        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var suppliers = this.suppliersRepository.GetEntity(id);

            GetSuppliersModel model = new GetSuppliersModel()
            {
                CreationDate = suppliers.CreationDate,
                ModifyDate = suppliers.ModifyDate,
                ContactName = suppliers.ContactName,
                CompanyName = suppliers.CompanyName

            };

            return Ok(suppliers);

        }
            // POST api/<SuppliersController>
            [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
