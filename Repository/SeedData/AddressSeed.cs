using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    public class AddressSeed : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var addresses = new List<Address>()
            {
                new Address()
                {
                    AddressName = "This is a address for kullanici1",
                    UserId = 1
                },
                new Address()
                {
                    AddressName = "This is a address for kullanici2",
                    UserId = 2
                }
            };

            builder.HasData(addresses);
        }
    }
}
