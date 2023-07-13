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
    public class ProductOrderSeed : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            var productOrders = new List<ProductOrder>()
            {
                new ProductOrder() { OrderId = 1,ProductId = 1},
                new ProductOrder() { OrderId = 1,ProductId = 4},
                new ProductOrder() { OrderId = 1,ProductId = 7},
                new ProductOrder() { OrderId = 1,ProductId = 34},
                new ProductOrder() { OrderId = 2,ProductId = 55},
                new ProductOrder() { OrderId = 2,ProductId = 14},
                new ProductOrder() { OrderId = 2,ProductId = 123},
                new ProductOrder() { OrderId = 2,ProductId = 88},
                new ProductOrder() { OrderId = 2,ProductId = 22},
                new ProductOrder() { OrderId = 3,ProductId = 89}
            };
            builder.HasData(productOrders);
        }
    }
}
