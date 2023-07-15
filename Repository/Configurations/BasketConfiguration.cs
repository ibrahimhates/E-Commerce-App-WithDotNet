
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.UserId);
         

            builder.Property(x => x.Total).HasColumnType("decimal(18,4)");

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Cart)
                   .HasForeignKey<Cart>(x => x.UserId);
        }
    }
}
