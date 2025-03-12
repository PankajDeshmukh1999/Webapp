using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Product.Models.Data;
using Product.Models.Entities;

namespace Product.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private ApplicationDbContext applicationDbContext;

        public ProductRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

         async Task<Product1> IProductRepository.AddProduct(Product1 product)
        {
            applicationDbContext.product.Add(product);
            await applicationDbContext.SaveChangesAsync();
            return product;
        }

        async Task<bool> IProductRepository.DeleteProductById(int Id)
        {
            var product = await applicationDbContext.product.FindAsync(Id);

            if(product is null)
            {
                return false;
            }
            applicationDbContext.Remove(product);
            await applicationDbContext.SaveChangesAsync();

            return true;
        }

        async Task<IEnumerable<Product1>> IProductRepository.GetAllProductList()
        {
            return await applicationDbContext.product.ToListAsync();
        }

        async Task<Product1?> IProductRepository.GetProductById(int Id)
        {
            return await applicationDbContext.product.FindAsync(Id);
        }

        async Task<bool> IProductRepository.UpdateProductById(Product1 product)
        {
            var existingProduct = await applicationDbContext.product.FindAsync(product.Id);
            if(existingProduct is null)
            {
                return false;
            }
            existingProduct.Name = product.Name;
            existingProduct.Desciption = product.Desciption;
            existingProduct.Price = product.Price;

            await applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
