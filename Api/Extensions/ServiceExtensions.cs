using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories.Abstracts;
using Repository.Repositories.Concretes;
using Repository.UnitOfWorks;
using System;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            var conn = configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<ETContext>(options =>
                    options.UseSqlServer(conn)
                );
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole<int>>(opt =>
            {
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ETContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<IProductBasketRepository, ProductBasketRepository>();
        }
    }
}
