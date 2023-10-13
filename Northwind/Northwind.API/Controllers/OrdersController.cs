using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models.Modules.OrdersAddModel;
using Northwind.API.Models.Modules.OrdersDetailsAddModel;
using Northwind.API.Models.Modules.OrdersDetailsGetAllModel;
using Northwind.API.Models.Modules.OrdersDetailsUpdateModel;
using Northwind.API.Models.Modules.OrdersGetAllModel;
using Northwind.API.Models.Modules.OrdersUpdateModel;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;



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

        [HttpGet("GetOrdersByOrderID")]
        public IActionResult GetOrdersByOrderID(int ordersID)
        {
            var orders = this.ordersRepository.GetOrdersByOrderID(ordersID);
            return Ok(orders);
        }

        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var orders = this.ordersRepository.GetEntities().Select(orders => new OrdersGetAllModel()
            {
                CustomerID = orders.CustomerID,
                ModifyDate = orders.ModifyDate,
                CreationUser = orders.CreationUser,
                EmployeeID = orders.EmployeeID,

            }).ToList();

            return Ok(orders);


        }

        // GET api/<CourseController>/5
        [HttpGet("Getorders")]
        public IActionResult GetOrders(int id)
        {
            var orders = this.ordersRepository.GetEntity(id);
            return Ok(orders);
        }

        [HttpPost("SaveOrders")]
        public IActionResult Post([FromBody] OrdersAddModel ordersAdd)
        {
            Orders orders = new Orders()
            {
                CreationDate = ordersAdd.ChanageDate,
                CreationUser = ordersAdd.ChangeUser,
                ModifyDate = ordersAdd.ChangeModifyDate


            };

            this.ordersRepository.Save(orders);

            return Ok();
        }

        // PUT api/<ShippersController>/5

        [HttpPost("UpdateCourse")]
        public IActionResult Put([FromBody] OrdersUpdateModel ordersUpdate)
        {
            Orders orders = new Orders()
            {
                EmployeeID = ordersUpdate.EmployeeID,
                CustomerID = ordersUpdate.CustomerID,
                ModifyDate = ordersUpdate.ModifyDate,
                CreationUser = ordersUpdate.CreationUser,


            };

            this.ordersRepository.Update(orders);

            return Ok();
        }
        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
