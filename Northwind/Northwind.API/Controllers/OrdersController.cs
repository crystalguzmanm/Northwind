using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using IOrdersRepository = Northwind.Domain.Repository.IOrdersRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        // GET: api/<ShippersController>
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            var Orders = this.ordersRepository.GetOrders();
            return Orders;


        }
        // GET: api/<OrdersController>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
