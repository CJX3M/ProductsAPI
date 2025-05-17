using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductsAPI
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InventoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<InventoryContext>>()))
            {
                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }
                var products = new Product[]
                {
                    new() { Id = 1, Name = "Apple iPhone 13", Description = "128GB, Blue", Price = 799.99m, Stock = 30 },
                    new() { Id = 2, Name = "Samsung Galaxy S21", Description = "128GB, Phantom Gray", Price = 699.99m, Stock = 100 },
                    new() { Id = 3, Name = "Google Pixel 6", Description = "128GB, Sorta Seafoam", Price = 599.99m, Stock = 60 },
                    new() { Id = 4, Name = "Apple MacBook Pro", Description = "13\", M1, 256GB SSD", Price = 1299.99m, Stock = 45 },
                    new() { Id = 5, Name = "Dell XPS 13", Description = "13\", i7, 512GB SSD", Price = 1099.99m, Stock = 25 },
                    new() { Id = 6, Name = "HP Spectre x360", Description = "14\", i5, 256GB SSD", Price = 999.99m, Stock = 10 },
                    new() { Id = 7, Name = "Apple iPad Pro", Description = "11\", 128GB, Silver", Price = 799.99m, Stock = 27 },
                    new() { Id = 8, Name = "Samsung Galaxy Tab S7", Description = "11\", 128GB, Mystic Black", Price = 649.99m, Stock = 36 },
                    new() { Id = 9, Name = "Amazon Fire HD 10", Description = "10.1\", 32GB, Black", Price = 149.99m, Stock = 61 },
                    new() { Id = 10, Name = "Herman Miller Aeron", Description = "Ergonomic Office Chair", Price = 1199.99m, Stock = 76 }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
