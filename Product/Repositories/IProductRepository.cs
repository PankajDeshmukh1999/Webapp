using Product.Models.Entities;

namespace Product.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product1>> GetAllProductList();
        Task<Product1?> GetProductById(int Id);
        Task<Product1> AddProduct(Product1 product);
        Task<bool> UpdateProductById(Product1 product1);
        Task<bool> DeleteProductById(int Id);
    }
}
