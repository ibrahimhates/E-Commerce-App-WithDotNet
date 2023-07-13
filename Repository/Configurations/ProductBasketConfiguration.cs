﻿
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ProductBasketConfiguration : IEntityTypeConfiguration<ProductBasket>
    {
        public void Configure(EntityTypeBuilder<ProductBasket> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.BasketId });

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.Baskets)
                   .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Basket)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.BasketId);
        }
    }
}
