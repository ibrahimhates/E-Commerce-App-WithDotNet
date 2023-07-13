using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var categories = new List<Category>();
            for(int i = 1; i <= 30; i++)
            {
                categories.Add(
                    new Category
                    {
                        Id = i,
                        Name = $"Category {i}"
                    }
                );
            }

            builder.HasData(categories);
        }
    }
}
