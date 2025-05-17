using ProductsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<bool> AddStockAsync(int productionId, int quantity);
        Task<bool> RemoveStockAsync(int productionId, int quantity);
    }
}
