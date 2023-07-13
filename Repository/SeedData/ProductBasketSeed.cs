using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SeedData
{
    public class ProductBasketSeed : IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> builder)
        {
            var productBaskets = new List<ProductCart>()
            {
                new ProductCart(){BasketId = 1,ProductId = 33},
                new ProductCart(){BasketId = 1,ProductId = 54},
                new ProductCart(){BasketId = 1,ProductId = 55},
                new ProductCart(){BasketId = 1,ProductId = 22},
                new ProductCart(){BasketId = 2,ProductId = 152},
                new ProductCart(){BasketId = 2,ProductId = 88},
                new ProductCart(){BasketId = 2,ProductId = 33}
            };
            builder.HasData(productBaskets);
        }
    }
}
