using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Core.Products;

namespace Petshop.Infra.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(150);

            builder.HasData(
            new Product
            {

                Description = "قلاده",
                Name = "pro01",
                CategoryId = 1,
                Price = 10000000,
                Id = 1

            },
            new Product
            {

                Description = "غذای خشک",
                Name = "pro02",
                CategoryId = 2,
                Price = 200000,
                Id = 2


            },
            new Product
            {

                Description = "حوله",
                Name = "pro03",
                CategoryId = 3,
                Price = 30000,
                Id = 3
            },
            new Product
            {

                Description = "ظرف آب",
                Name = "pro04",
                CategoryId = 2,
                Price = 800000,
                Id = 4
            },
            new Product
            {

                Description = "کنسرو",
                Name = "pro05",
                CategoryId = 3,
                Price = 30000,
                Id = 5
            },
            new Product
            {

                Description = "شامپو",
                Name = "pro06",
                CategoryId = 3,
                Price = 30000,
                Id = 6
            },
            new Product
            {

                Description = "کفش",
                Name = "pro07",
                CategoryId = 1,
                Price = 3000000,
                Id = 7
            }
                );

        }



    }
}
