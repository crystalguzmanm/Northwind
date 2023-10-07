﻿using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;
using IOrdersDetailsRepository = Northwind.Domain.Repository.IOrdersDetailsRepository;

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

        // GET: api/<SuppliersController>
        [HttpGet]
        public IEnumerable<OrdersDetails> Get()
        {
            var OrdersDetails = this.ordersDetailsRepository.GetOrdersDetails();
            return OrdersDetails;


        }


        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}