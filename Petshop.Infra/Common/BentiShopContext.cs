using Microsoft.EntityFrameworkCore;
using Petshop.Core.Categories;
using Petshop.Core.Orders;
using Petshop.Core.Products;
using System.Reflection;

namespace Petshop.Infra.Common
{
    public class BentiShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }


        public BentiShopContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
