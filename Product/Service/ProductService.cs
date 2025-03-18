using Microsoft.EntityFrameworkCore;
using Product.Models.Data;
using Product.Models.Entities;
using Product.Repositories;

namespace Product.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private ApplicationDbContext applicationDbContext;

        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }

        public ProductService(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Product1> AddProduct(Product1 product)
        => await productRepository.AddProduct(product);

        public async Task<bool> DeleteProductById(int Id)
        => await productRepository.DeleteProductById(Id);

        public async Task<IEnumerable<Product1>> GetAllProductList()
            => await productRepository.GetAllProductList();

        public async Task<Product1?> GetProductById(int Id) =>
            await productRepository.GetProductById(Id);


        public async Task<bool> UpdateProductById(Product1 product1)
        => await productRepository.UpdateProductById(product1);
    }
}
