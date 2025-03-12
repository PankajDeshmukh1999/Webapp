using Microsoft.EntityFrameworkCore;
using Product.Models.Entities;

namespace Product.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<Product1> product { get; set; }
       
    }
}
