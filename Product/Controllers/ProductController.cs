using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Product.Models.Entities;
using Product.Service;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;

        public ProductController(IProductService service)
        {
            productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await productService.GetAllProductList());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            return Ok(await productService.GetProductById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product1 product1)
        {
            return Ok(await productService.AddProduct(product1));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct(int Id, [FromBody] Product1 product1)
        {
            if (Id != product1.Id)
                return BadRequest("Product ID mismatch.");

            var updated = await productService.UpdateProductById(product1);
            return Ok(updated);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var result = await productService.DeleteProductById(Id);
            return Ok(result);

        }
    }
}
