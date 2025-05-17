using ProductsAPI.Models;
using ProductsAPI.Repositories;

namespace ProductsAPI.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return _productRepository.GetAllAsync();
        }
        public Task<Product?> GetProductByIdAsync(int id)
        {
            return _productRepository.GetByIdAsync(id);
        }
        public Task<Product> CreateProductAsync(Product product)
        {
            return _productRepository.AddAsync(product);
        }
        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
            // Update the properties of the existing product
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;            

            return await _productRepository.UpdateAsync(product);
        }
        public Task<bool> DeleteProductAsync(int id)
        {
            return _productRepository.DeleteAsync(id);
        }
        public Task<bool> AddStockAsync(int productId, int quantity)
        {
            return _productRepository.AddStockAsync(productId, quantity);
        }
        public Task<bool> RemoveStockAsync(int productId, int quantity)
        {
            return _productRepository.RemoveStockAsync(productId, quantity);
        }
    }    
}
