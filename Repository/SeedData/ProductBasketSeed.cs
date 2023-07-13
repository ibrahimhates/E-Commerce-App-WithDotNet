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
    public class ProductBasketSeed : IEntityTypeConfiguration<ProductBasket>
    {
        public void Configure(EntityTypeBuilder<ProductBasket> builder)
        {
            var productBaskets = new List<ProductBasket>()
            {
                new ProductBasket(){BasketId = 1,ProductId = 33},
                new ProductBasket(){BasketId = 1,ProductId = 54},
                new ProductBasket(){BasketId = 1,ProductId = 55},
                new ProductBasket(){BasketId = 1,ProductId = 22},
                new ProductBasket(){BasketId = 2,ProductId = 152},
                new ProductBasket(){BasketId = 2,ProductId = 88},
                new ProductBasket(){BasketId = 2,ProductId = 33}
            };
            builder.HasData(productBaskets);
        }
    }
}
