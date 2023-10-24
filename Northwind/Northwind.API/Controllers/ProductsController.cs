using Microsoft.AspNetCore.Mvc;
using Northwind.API.DTOs;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;
using IProductsRepository = Northwind.Domain.Repository.IProductsRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        //private readonly IProductsRepository productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = new List<ProductsDTO>();

            try
            {
                foreach(var product in await _productsRepository.GetAll()) 
                {
                    products.Add(new ProductsDTO
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        SupplierID = product.SupplierID,
                        CategoryID = product.CategoryID,
                        QuantityPerUnit = product.QuantityPerUnit,
                        UnitPrice = product.UnitPrice,
                        UnitsInStock = product.UnitsInStock,
                        UnitsOnOrder = product.UnitsOnOrder,
                        ReorderLevel = product.ReorderLevel,
                        Discontinued = product.Discontinued,
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(products);


        }
        // GET: api/<ProductsController>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}