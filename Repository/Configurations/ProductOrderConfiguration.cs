using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(x => new {x.OrderId, x.ProductId});

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.OrderId);
            
            builder.HasOne(x => x.Product)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.ProductId);
        }
    }
}
