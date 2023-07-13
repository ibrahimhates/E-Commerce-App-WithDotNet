using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    public class CartSeed : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            var baskets = new List<Cart>()
            {
                new Cart(){UserId = 1,Total = 200 },
                new Cart(){UserId = 2,Total = 200 },
            };
            builder.HasData(baskets);
        }
    }
}
