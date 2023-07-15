
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.AddressName).IsRequired().HasMaxLength(200);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Address)
                   .HasForeignKey<Address>(x => x.UserId);
        }
    }
}
