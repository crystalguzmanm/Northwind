using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models.Modules.Customers;
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
        private readonly ICustomersRepository CustomersRepository;
        public CustomersController(ICustomersRepository CustomersRepository)
        {
            this.CustomersRepository = CustomersRepository;
        }


        // GET: api/<CustomersController>
        [HttpGet("GetCustomersByCustomerID")]
        public IActionResult GetCustomersByCustomerID(int CustomerID)
        {
            var Customers = this.CustomersRepository.GetCustomersByCustomerID(CustomerID);
            return Ok(Customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet]
        public IActionResult Get()
        {
            var Customers = this.CustomersRepository.GetEntities().Select(Customers => new GetCustomersModel()
            {
                CompanyName = Customers.CompanyName,
                City = Customers.City,
                Phone = Customers.Phone,
                Address = Customers.Address

            }).ToList();

            return Ok(Customers);
        }

        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers(int id)
        {
            var Customers = this.CustomersRepository.GetEntity(id);
            return Ok(Customers);
        }

        // POST api/<CustomersController>
        [HttpPost("SaveCustomers")]
        public IActionResult Post([FromBody] AddCustomersModel addCustomers)
        {
            Customers customers = new Customers()
            {
                CompanyName = addCustomers.CompanyName,
                City = addCustomers.City,
                Phone = addCustomers.Phone,
                Address = addCustomers.Address
            };

            this.CustomersRepository.Save(customers);
            return Ok();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("UpdateCustomers")]
        public IActionResult Put([FromBody] UpdateCustomersModelcs updateCustomers)
        {
            Customers customers = new Customers()
            {
                CompanyName = updateCustomers.CompanyName,
                City = updateCustomers.City,
                Phone = updateCustomers.Phone,
                Address = updateCustomers.Address
            };

            this.CustomersRepository.Update(customers);

            return Ok();
        }
    }
}
