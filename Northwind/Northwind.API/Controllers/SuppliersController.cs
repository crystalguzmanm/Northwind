using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.ShippersAddModel;
using Northwind.API.Models.Modules.ShippersGetAllModel;
using Northwind.API.Models.Modules.ShippersUpdateModel;
using Northwind.API.Models.Modules.SuppliersAddModel;
using Northwind.API.Models.Modules.SuppliersGetAllModel;
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

        [HttpGet("GetSuppliersBysuppliersId")]
        public IActionResult GetSuppliersBySuppliersId(int suppliersId)
        {
            var suppliers = this.GetSuppliersBySuppliersId(suppliersId);
            return Ok(suppliers);
        }


        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            var suppliers = this.suppliersRepository.GetEntities().Select(suppliers => new SuppliersGetAllModelcs()
            {
                CreationDate = suppliers.CreationDate,
                ModifyDate = suppliers.ModifyDate,
                ContactName = suppliers.ContactName,
                CompanyName = suppliers.CompanyName

            }).ToList();

            return Ok(suppliers);


        }


        [HttpGet("Getsuppliers")]
        public IActionResult Getsuppliers(int id)
        {
            var suppliers = this.suppliersRepository.GetEntity(id);
            return Ok(suppliers);
        }


        [HttpPost("SaveSuppliers")]
        public IActionResult Post([FromBody] SuppliersAddModel suppliersAdd)
        {
            Suppliers suppliers = new Suppliers()
            {
                CreationDate = suppliersAdd.ChanageDate,
                CreationUser = suppliersAdd.ChangeUser,
                ModifyDate = suppliersAdd.ChangeModifyDate


            };

            this.suppliersRepository.Save(suppliers);

            return Ok();
        }

        [HttpPost("UpdateCourse")]
        public IActionResult Put([FromBody] ShippersUpdateModel suppliersUpdate)
        {
            Suppliers suppliers = new Suppliers()
            {
                CreationDate = suppliersUpdate.CreationDate,
                CompanyName = suppliersUpdate.CompanyName,
                ModifyDate = suppliersUpdate.ModifyDate


            };

            this.suppliersRepository.Update(suppliers);

            return Ok();
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
