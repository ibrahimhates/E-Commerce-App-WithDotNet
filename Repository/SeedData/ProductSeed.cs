using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var products = new List<Product>();
            var random = new Random();
            for(int i = 0; i < 180; i++) 
            {
                products.Add(
                    new Product
                    {
                        Id = i+1,
                        Name = $"Product {i+1}",
                        Description = $"Description {i+1}",
                        CreatedDate = DateTime.Now,
                        Price = Convert.ToDecimal(random.Next(50, 10000)),
                        StockStatus = true,
                        CategoryId = (i%30)+1,
                        
                    }
                );
            }

            builder.HasData(products);
        }
    }
}
