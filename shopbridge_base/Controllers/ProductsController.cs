using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return Ok(await productService.GetAllProducts());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result= await productService.GetProduct(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(product);
            }
            var updatedProduct = await productService.UpdateProduct(id, product);
            return Ok(updatedProduct);
        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(product);
            }
            var addedProduct = await productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = addedProduct.Id }, product);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedProduct = await productService.DeleteProduct(id);
            if (deletedProduct != null)
                return Ok(deletedProduct);
            else
                return NotFound(deletedProduct);
        }

        private bool ProductExists(int id)
        {
            return productService.GetProduct(id) == null ? false : true;
        }
    }
}
