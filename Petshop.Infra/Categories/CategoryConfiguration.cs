using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Core.Categories;

namespace Petshop.Infra.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "لوازم ضروری"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "غذا"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "شستشو"
                }
                );

        }

    }
}
