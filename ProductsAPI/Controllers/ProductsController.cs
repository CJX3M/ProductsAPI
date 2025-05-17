using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductsController
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        // GET: ProductsController/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Post: ProductsController
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _productService.CreateProductAsync(product);
            return Ok(product);
        }

        // PUT: ProductsController/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.UpdateProductAsync(id, product);
            if (!result) return NotFound();
            return Ok(product);
        }

        // DELETE: ProductsController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
