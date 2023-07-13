

using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Price).HasColumnType("decimal(18,4)");
            builder.Property(x => x.StockStatus).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);

        }
    }
}
