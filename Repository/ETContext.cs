using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class ETContext : IdentityDbContext<User, IdentityRole<int>,int>
    {
        public ETContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<ProductBasket> ProductBaskets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
