using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models.Modules.Shippers;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShippersRepository shippersRepository;

        public ShippersController(IShippersRepository shippersRepository)
        { 
          this.shippersRepository = shippersRepository;
        }


        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var shippers = this.shippersRepository.GetEntities().Select(shippers => new GetShippersModel()
            {
                CreationDate = shippers.CreationDate,
                ModifyDate = shippers.ModifyDate,
                Phone = shippers.Phone,
                CompanyName = shippers.CompanyName

            });

            return Ok (shippers);


        }

        // GET api/<ShippersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shippers = this.shippersRepository.GetEntity(id);

            GetShippersModel model = new GetShippersModel()
            {
                CreationDate = shippers.CreationDate,
                CompanyName = shippers.CompanyName,
                ModifyDate = shippers.ModifyDate


            };

            return Ok(shippers);

        }

        // POST api/<ShippersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShippersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShippersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
