

using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    public class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var orders = new List<Order>()
            {
                new Order 
                { 
                    Id = 1,
                    UserId = 1,
                    DeliveryStatus = false,
                    PaymentStatus = false,
                    OrderDate = DateTime.Now.AddDays(-2),
                    TotalAmount = 100,
                },
                new Order 
                { 
                    Id = 2,
                    UserId = 2,
                    DeliveryStatus = false,
                    PaymentStatus = true,
                    OrderDate = DateTime.Now,
                    TotalAmount = 100,
                },
                new Order
                {
                    Id = 3,
                    UserId = 2,
                    DeliveryStatus = true,
                    PaymentStatus = true,
                    OrderDate = DateTime.Now.AddDays(-5),
                    TotalAmount= 100,
                    
                },
            };
            
            builder.HasData(orders);
        }
    }
}
