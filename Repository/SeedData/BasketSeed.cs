using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    public class BasketSeed : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            var baskets = new List<Basket>()
            {
                new Basket(){UserId = 1,Total = 200 },
                new Basket(){UserId = 2,Total = 200 },
            };
            builder.HasData(baskets);
        }
    }
}
