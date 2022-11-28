using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Core.Orders;

namespace Petshop.Infra.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Address).IsRequired().HasComment("please enter a address name");
            builder.Property(c => c.City).IsRequired().HasComment("please enter a city name");
            builder.Property(c => c.Country).IsRequired().HasComment("please enter a country name");
            builder.Property(c => c.FullName).IsRequired().HasComment("please enter a FullName");


        }
    }
}
