using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.OrdersDetailsAddModel;
using Northwind.API.Models.Modules.OrdersDetailsGetAllModel;
using Northwind.API.Models.Modules.OrdersDetailsUpdateModel;
using Northwind.Application.Contracts;
using Northwind.Application.Dtos.Orders;
using Northwind.Application.Dtos.OrdersDetails;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using System.Numerics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDetailsController : ControllerBase
    {
        private readonly IOrdersDetailsServices ordersDetailsServices;


        public OrdersDetailsController(IOrdersDetailsServices ordersDetailsServices)
        {
            this.ordersDetailsServices = ordersDetailsServices;
        }
        //TODO
        [HttpGet("GetOrdersDetailsByOrderID")]
        public IActionResult GetOrdersDetailsByOrderID(int ordersDetailsID)
        {
            var ordersDetails = this.ordersDetailsServices.GetOrdersDetailsByOrderDetailsID(ordersDetailsID);
            return Ok(ordersDetails);
        }

        // GET: api/<OrdersDetailsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.ordersDetailsServices.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);


        }

        // GET api/<CourseController>/5
        [HttpGet("GetordersDetails")]
        public IActionResult GetOrdersDetails(int id)
        {
            var result = this.ordersDetailsServices.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveOrdersDetails")]
        public IActionResult Post([FromBody] OrdersDetailsDtoAdd ordersDetailsApp)
        {
            var result = this.ordersDetailsServices.Save(ordersDetailsApp);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<ShippersController>/5

        [HttpPost("RemoveOrdersDetails")]
        public IActionResult Remove([FromBody] OrdersDetailsDtoRemove ordersDetailsDtoRemove)
        {
            var result = this.ordersDetailsServices.Remove(ordersDetailsDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateordersDetails")]
        public IActionResult Put([FromBody] OrdersDetailsDtoUpdate ordersDetailsDtoUpdate)
        {
            var result = this.ordersDetailsServices.Update(ordersDetailsDtoUpdate);

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
