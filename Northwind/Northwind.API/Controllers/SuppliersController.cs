using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Framing;
using Northwind.API.Models.Modules.ShippersAddModel;
using Northwind.API.Models.Modules.ShippersGetAllModel;
using Northwind.API.Models.Modules.ShippersUpdateModel;
using Northwind.API.Models.Modules.SuppliersAddModel;
using Northwind.API.Models.Modules.SuppliersGetAllModel;
using Northwind.Application.Contracts;
using Northwind.Application.Dtos.Shippers;
using Northwind.Application.Dtos.Suppliers;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }

       


        [HttpGet("GetSuppliersBysuppliersId")]
        public IActionResult GetSuppliersBySuppliersId(int suppliersId)
        {
            var suppliers = this.GetSuppliersBySuppliersId(suppliersId);
            return Ok(suppliers);
        }


        // GET api/<SuppliersController>/5
        

        [HttpGet("Getsuppliers")]
        public IActionResult Get()
        {
            var result = this.suppliersService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);



        }


        [HttpGet("{id}")]
        public IActionResult Getsuppliers(int id)
        {
            var result = this.suppliersService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);
        }


        [HttpPost("SaveSuppliers")]
        public IActionResult Post([FromBody] SuppliersDtoAdd suppliersAdd)
        {
            var result = this.suppliersService.Save(suppliersAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPut("Updatesuppliers")]
        public IActionResult Put([FromBody] SuppliersDtoUpdate suppliersUpdate)
        {
            var result = this.suppliersService.Update(suppliersUpdate);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("RemoveSuppliers")]
        public IActionResult Remove([FromBody] SuppliersDtoRemove suppliersDtoRemove)
        {
            var result = this.suppliersService.Remove(suppliersDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
