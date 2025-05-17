using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProductsAPI.Data;
using ProductsAPI.Repositories;
using ProductsAPI.Models;
using Assert = Xunit.Assert;


namespace ProductsAPI.Test
{
    public class ProductsServiceTest
    {
        private InventoryContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            return new InventoryContext(options);
        }

        [Fact]
        public async Task AddProduct_ShouldAddProduct()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product = new Product { Name = "Test Product", Price = 10.0m, Stock = 5 };
            // Act
            var result = await repository.AddAsync(product);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
            Assert.Equal(10.0m, result.Price);
            Assert.Equal(5, result.Stock);
        }

        [Fact]
        public async Task AddStock_ShouldIncreaseStock()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product = new Product { Name = "Test Product", Price = 10.0m, Stock = 5 };
            await repository.AddAsync(product);
            // Act
            var result = await repository.AddStockAsync(product.Id, 10);
            // Assert
            Assert.True(result);
            var updatedProduct = await context.Products.FindAsync(product.Id);
            Assert.Equal(15, updatedProduct?.Stock);
        }

        [Fact]
        public async Task RemoveStock_ShouldDecreaseStock()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product = new Product { Name = "Test Product", Price = 10.0m, Stock = 5 };
            await repository.AddAsync(product);
            // Act
            var result = await repository.RemoveStockAsync(product.Id, 2);
            // Assert
            Assert.True(result);
            var updatedProduct = await context.Products.FindAsync(product.Id);
            Assert.Equal(3, updatedProduct?.Stock);
        }

        [Fact]
        public async Task RemoveStock_ShouldReturnFalse_WhenInsufficientStock()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product = new Product { Name = "Test Product", Price = 10.0m, Stock = 10 };
            await repository.AddAsync(product);
            // Act
            var result = await repository.RemoveStockAsync(product.Id, 5);
            // Assert
            Assert.True(result);
            var updatedProduct = await context.Products.FindAsync(product.Id);
            Assert.Equal(5, updatedProduct?.Stock);
        }

        [Fact]
        public async Task DeleteProduct_ShouldRemoveProduct()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product = new Product { Name = "Test Product", Price = 10.0m, Stock = 5 };
            await repository.AddAsync(product);
            // Act
            var result = await repository.DeleteAsync(product.Id);
            // Assert
            Assert.True(result);
            var deletedProduct = await context.Products.FindAsync(product.Id);
            Assert.Null(deletedProduct);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product1 = new Product { Name = "Test Product 1", Price = 10.0m, Stock = 5 };
            var product2 = new Product { Name = "Test Product 2", Price = 20.0m, Stock = 10 };
            await repository.AddAsync(product1);
            await repository.AddAsync(product2);
            // Act
            var products = await repository.GetAllAsync();
            // Assert
            Assert.Equal(2, products.Count());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnProduct()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repository = new ProductRepositories(context);
            var product = new Product { Name = "Test Product", Price = 10.0m, Stock = 5 };
            await repository.AddAsync(product);
            // Act
            var result = await repository.GetByIdAsync(product.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
        }
    }
}