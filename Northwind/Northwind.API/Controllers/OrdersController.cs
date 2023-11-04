using Microsoft.AspNetCore.Mvc;

using Northwind.API.Models.Modules.OrdersAddModel;
using Northwind.API.Models.Modules.OrdersGetAllModel;
using Northwind.API.Models.Modules.OrdersUpdateModel;
using Northwind.Application.Contracts;
using Northwind.Application.Dtos.Orders;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using System.Numerics;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices ordersServices;

        
        public OrdersController(IOrdersServices ordersServices) 
        {
            this.ordersServices = ordersServices;
        }
        //TODO
        [HttpGet("GetOrdersByOrderID")]
        public IActionResult GetOrdersByOrderID(int ordersID)
        {
            var orders = this.ordersServices.GetOrdersByOrderID(ordersID);
            return Ok(orders);
        }

        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.ordersServices.GetAll();

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);


        }

        // GET api/<CourseController>/5
        [HttpGet("Getorders")]
        public IActionResult GetOrders(int id)
        {
            var result = this.ordersServices.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveOrders")]
        public IActionResult Post([FromBody] OrdersDtoAdd ordersApp)
        {
            var result = this.ordersServices.Save(ordersApp);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut("Updateorders")]
        public IActionResult Put([FromBody] OrdersDtoUpdate ordersDtoUpdate)
        {
            var result = this.ordersServices.Update(ordersDtoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<ShippersController>/5

        [HttpPost("RemoveCourse")]
        public IActionResult Remove([FromBody] OrdersDtoRemove ordersDtoRemove)
        {
            var result = this.ordersServices.Remove(ordersDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
