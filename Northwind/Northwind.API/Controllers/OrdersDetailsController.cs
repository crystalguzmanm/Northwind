using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.OrdersDetailsAddModel;
using Northwind.API.Models.Modules.OrdersDetailsGetAllModel;
using Northwind.API.Models.Modules.OrdersDetailsUpdateModel;
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
        private readonly IOrdersDetailsRepository ordersDetailsRepository;

        public OrdersDetailsController(IOrdersDetailsRepository ordersDetailsRepository)
        {
            this.ordersDetailsRepository = ordersDetailsRepository;
        }

        [HttpGet("GetOrdersDetailsByOrderDetailID")]
        public IActionResult GetOrdersDetailsByOrderDetailID(int ordersDetailsID)
        {
            var ordersDetails = this.ordersDetailsRepository.GetOrdersDetailsByOrderDetailID(ordersDetailsID);
            return Ok(ordersDetails);
        }

        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var ordersDetails = this.ordersDetailsRepository.GetEntities().Select(ordersDetails => new OrdersDetailsGetAllModel()
            {
                CreationDate = ordersDetails.CreationDate,
                ModifyDate = ordersDetails.ModifyDate,
                ProductID = ordersDetails.ProductID,
                UnitPrice = ordersDetails.UnitPrice,
                Quantity = ordersDetails.Quantity,
                Discount = ordersDetails.Discount,
                CreationUser = ordersDetails.CreationUser,

            }).ToList();

            return Ok(ordersDetails);


        }

        // GET api/<CourseController>/5
        [HttpGet("GetordersDetails")]
        public IActionResult GetOrdersDetails(int id)
        {
            var ordersDetails = this.ordersDetailsRepository.GetEntity(id);
            return Ok(ordersDetails);
        }


        [HttpPost("SaveOrdersDetails")]
        public IActionResult Post([FromBody] OrdersDetailsAddModel ordersDetailsAdd)
        {
            OrdersDetails ordersDetails = new OrdersDetails()
            {
                CreationDate = ordersDetailsAdd.ChanageDate,
                CreationUser = ordersDetailsAdd.ChangeUser,
                ModifyDate = ordersDetailsAdd.ChangeModifyDate,
                OrderDetailsID = ordersDetailsAdd.OrderDetailsID,
                Quantity = ordersDetailsAdd.Quantity,
                ProductID = ordersDetailsAdd.ProductID



            };

            this.ordersDetailsRepository.Save(ordersDetails);

            return Ok();
        }


        // PUT api/<ShippersController>/5

        [HttpPost("UpdateCourse")]
        public IActionResult Put([FromBody] OrdersDetailsUpdateModel ordersDetailsUpdate)
        {
            OrdersDetails ordersDetails = new OrdersDetails()
            {
                CreationDate = ordersDetailsUpdate.CreationDate,
                ModifyDate = ordersDetailsUpdate.ModifyDate,
                ProductID = ordersDetailsUpdate.ProductID,
                UnitPrice = ordersDetailsUpdate.UnitPrice,
                Quantity = ordersDetailsUpdate.Quantity,
                Discount = ordersDetailsUpdate.Discount,
                CreationUser = ordersDetailsUpdate.CreationUser,


            };

            this.ordersDetailsRepository.Update(ordersDetails);

            return Ok();
        }

        

        // DELETE api/<OrdersDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
