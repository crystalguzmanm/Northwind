using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.ShippersAddModel;
using Northwind.API.Models.Modules.ShippersGetAllModel;
using Northwind.API.Models.Modules.ShippersUpdateModel;
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


        [HttpGet("GetShippersByshippersId")]
        public IActionResult GetShippersByshippersId(int shippersId)
        {
            var shippers = this.shippersRepository.GetShippersByShippersID(shippersId);
            return Ok(shippers);
        }

        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var shippers = this.shippersRepository.GetEntities().Select(shippers => new ShippersGetAllModel()
            {
                CreationDate = shippers.CreationDate,
                ModifyDate = shippers.ModifyDate,
                Phone = shippers.Phone,
                CompanyName = shippers.CompanyName

            }).ToList();

            return Ok (shippers);


        }



        // GET api/<CourseController>/5
        [HttpGet("Getshippers")]
        public IActionResult GetShippers(int id)
        {
            var shippers = this.shippersRepository.GetEntity(id);
            return Ok(shippers);
        }



        [HttpPost("SaveShippers")]
        public IActionResult Post([FromBody] ShippersAddModelcs shippersAdd)
        {
            Shippers shippers = new Shippers()
            {
                CreationDate = shippersAdd.CreationDate,
                ModifyDate = shippersAdd.ModifyDate,
                Phone = shippersAdd.Phone,  
                CompanyName = shippersAdd.CompanyName 
                


            };

            this.shippersRepository.Save(shippers);

            return Ok();
        }


        // PUT api/<ShippersController>/5

        [HttpPut("Updateshippers")]
        public IActionResult Put([FromBody] ShippersUpdateModel shippersUpdate)
        {
            this.shippersRepository.Update(new Shippers()
            { ModifyDate = shippersUpdate.ChangeModifyDate,
              UserMod = shippersUpdate.ChangeUser,
              Phone = shippersUpdate.Phone, 
              CompanyName = shippersUpdate.CompanyName,
               CreationDate = shippersUpdate.CreationDate,
               CreationUser = shippersUpdate.ChangeUser,
                ShipperID = shippersUpdate.ShipperID






            });

          

            return Ok();
        }

        // DELETE api/<ShippersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
