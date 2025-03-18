using Microsoft.EntityFrameworkCore;
using Product.Models.Data;
using Product.Models.Entities;
using Product.Service;
using Xunit;

namespace Product.Test
{
    public class ProductServiceTests
    {

        private readonly ProductService productService;
        private readonly ApplicationDbContext applicationDbContext;

        public ProductServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            applicationDbContext = new ApplicationDbContext(options);
            applicationDbContext.Database.EnsureCreated();

            productService = new ProductService(applicationDbContext);
        }


        [Fact]
        public async Task GetAllProducts()
        {
            applicationDbContext.product.Add(new Product1 { Id = 1, Name = "Test Product", Desciption="Demo", Price=1000 });
            await applicationDbContext.SaveChangesAsync();

            var result = await productService.GetAllProductList();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Product", result.First().Name);

        }

        [Fact]
        public async Task GetProductById_ShouldReturnProduct_WhenProductExists()
        {
            // 🔥 Ensure fresh data for each test
            applicationDbContext.product.RemoveRange(applicationDbContext.product);
            await applicationDbContext.SaveChangesAsync();

            applicationDbContext.product.Add(new Product1 {Id = 1, Name = "Test Product", Desciption = "Demo", Price = 1000 });
            await applicationDbContext.SaveChangesAsync();

            var result = await productService.GetProductById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

    }
}
