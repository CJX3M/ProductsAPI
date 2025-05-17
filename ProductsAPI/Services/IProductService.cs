using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> AddStockAsync(int productId, int quantity);
        Task<bool> RemoveStockAsync(int productId, int quantity);
    }
}
