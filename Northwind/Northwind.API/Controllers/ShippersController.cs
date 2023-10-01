using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;

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
        public IEnumerable<Shippers> Get()
        {
           var Shippers = this.shippersRepository.GetShippers();
            return Shippers;


        }

        // GET api/<ShippersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
