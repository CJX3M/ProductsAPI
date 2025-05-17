using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly IProductService _productService;

        public StockController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/{productId}/{quantity}")]
        public async Task<IActionResult> AddStock(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }
            var result = await _productService.AddStockAsync(productId, quantity);
            if (!result)
            {
                return NotFound($"Product with ID {productId} not found.");
            }
            return Ok($"Stock for product ID {productId} updated successfully.");
        }

        [HttpDelete("/{productId}/{quantity}")]
        public async Task<IActionResult> RemoveStock(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }
            var result = await _productService.RemoveStockAsync(productId, quantity);
            if (!result)
            {
                return NotFound($"Product with ID {productId} not found or insufficient stock.");
            }
            return Ok($"Stock for product ID {productId} updated successfully.");
        }
    }
}
