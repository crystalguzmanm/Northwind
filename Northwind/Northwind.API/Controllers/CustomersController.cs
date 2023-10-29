using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models.Modules.Customers;
using Northwind.Application.Contracts;
using Northwind.Application.DTOs.Customers;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;
using System.Net;
using System.Numerics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService CustomersService;
        public CustomersController(ICustomersService customersService)
        {
            this.CustomersService = CustomersService;
        }


        // GET: api/<CustomersController>
        [HttpGet("GetCustomersByCustomerID")]
        public IActionResult GetCustomersByCustomerID(int CustomerID)
        {
            var Customers = this.CustomersService.GetById(CustomerID);
            return Ok(Customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.CustomersService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers(int id)
        {
            var result = this.CustomersService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<CustomersController>
        [HttpPost("SaveCustomers")]
        public IActionResult Post([FromBody] CustomersDtoAdd addCustomers)
        {
            var result = this.CustomersService.Save(addCustomers);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("UpdateCustomers")]
        public IActionResult Put([FromBody] CustomersDtoUpdate updateCustomers)
        {
            var result = this.CustomersService.Update(updateCustomers);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("RemoveCustomers")]
        public IActionResult Remove([FromBody] CustomersDtoRemove RemoveCustomers)
        {
            var result = this.CustomersService.Remove(RemoveCustomers);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
