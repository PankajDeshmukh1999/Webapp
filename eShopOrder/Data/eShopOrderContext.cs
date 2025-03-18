using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eShopOrder.Models;

namespace eShopOrder.Data
{
    public class eShopOrderContext : DbContext
    {
        public eShopOrderContext (DbContextOptions<eShopOrderContext> options)
            : base(options)
        {
        }

        public DbSet<eShopOrder.Models.Order> Order { get; set; } = default!;
    }
}
