using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models.Modules.ProductsAddModel;
using Northwind.API.Models.Modules.ProductsGetAllModel;
using Northwind.API.Models.Modules.ProductsUpdateModel;
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;

        //private readonly IProductsRepository productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet("GetProductsByProductID")]
        public IActionResult GetProductsByProductID(int ProductID)
        {
            var products = this.productsRepository.GetProductsByProductID(ProductID);
            return Ok(products);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = this.productsRepository.GetEntities().Select(products => new ProductsGetAllModel()
            {
                ProductName = products.ProductName,
                QuantityPerUnit = products.QuantityPerUnit,
                UnitPrice = products.UnitPrice,
                UnitsInStock = products.UnitsInStock,
                UnitsOnOrder = products.UnitsOnOrder,
                ReorderLevel = products.ReorderLevel,
                SupplierID = products.SupplierID,
                CategoryID = products.CategoryID,

            }).ToList();

            return Ok(products);


        }
        // GET: api/<ProductsController>
        [HttpGet("Getproducts")]
        public IActionResult GetProducts(int id)
        {
            var products = this.productsRepository.GetEntity(id);
            return Ok(products);
        }

        // POST api/<ProductsController>
        [HttpPost("SaveProducts")]
        public IActionResult Post([FromBody] ProductsAddModel productsAdd)
        {
            Products products = new Products()
            {
                CreationDate = productsAdd.ChangeDate,
                CreationUser = productsAdd.ChangeUser,
                ModifyDate = productsAdd.ChangeModifyDate,
                

            };

            this.productsRepository.Save(products);

            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("UpdateProducts")]
        public IActionResult Put([FromBody] ProductsUpdateModel productsUpdate)
        {
            Products products = new Products()
            {
                SupplierID = productsUpdate.SupplierID,
                CategoryID = productsUpdate.CategoryID,
                ModifyDate = productsUpdate.ModifyDate,
                CreationUser = productsUpdate.CreationUser,
                

            };

            this.productsRepository.Update(products);

            return Ok();
        }


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.productsRepository.Remove(this.productsRepository.GetEntity(id));
        }
    }
}