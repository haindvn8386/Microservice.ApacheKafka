using ApacheKafka.ProductApi.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApacheKafka.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await productService.AddProduct(product);
            return Created();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }
        
    }
}
