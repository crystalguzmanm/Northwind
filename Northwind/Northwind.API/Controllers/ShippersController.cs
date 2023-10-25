using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.ShippersAddModel;
using Northwind.API.Models.Modules.ShippersGetAllModel;
using Northwind.API.Models.Modules.ShippersUpdateModel;
using Northwind.Application.Contracts;
using Northwind.Application.Dtos.Shippers;
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
        private readonly IShippersService shippersService;

        public ShippersController(IShippersService shippersService)
        { 
          this.shippersService = shippersService;
        }


        [HttpGet("GetShippersByshippersId")]
        public IActionResult GetShippersByshippersId(int shippersId)
        {
            var shippers = this.shippersService.GetShippersByShippersID(shippersId);
            return Ok(shippers);
        }

        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.shippersService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok (result);


        }



        // GET api/<CourseController>/5
        [HttpGet("Getshippers")]
        public IActionResult GetShippers(int Id)
        {
            var result = this.shippersService.GetById(Id);

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);

        }



        [HttpPost("SaveShippers")]
        public IActionResult Post([FromBody] ShippersDtoAdd shippersAdd)
        {
            var result = this.shippersService.Save(shippersAdd);
            

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        // PUT api/<ShippersController>/5
        

        [HttpPut("Updateshippers")]
        public IActionResult Put([FromBody] ShippersDtoUpdate shippersDtoUpdate)
        {
            var result = this.shippersService.Update(shippersDtoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE api/<ShippersController>/5

        [HttpPut("Removeshippers")]
        public IActionResult Remove([FromBody] ShippersDtoRemove shippersDtoRemove)
        {
            var result = this.shippersService.Remove(shippersDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
