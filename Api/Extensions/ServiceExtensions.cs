﻿using Entity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentation.ActionFilter;
using Repository;
using Repository.Repositories;
using Repository.Repositories.Abstracts;
using Repository.Repositories.Concretes;
using Repository.UnitOfWorks;
using Service.Abstracts;
using Service.Abstracts.Auth;
using Service.Abstracts.LoggerAbstract;
using Service.Concrates;
using Service.Concrates.Auth;
using Service.Concrates.LoggerConcrate;
using System.Reflection;
using System.Text;

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

        public static void ConfigureRepositoriesInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<IProductBasketRepository, ProductBasketRepository>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
           services.AddSingleton<ILoggerService, LoggerManager>();
        public static void ConfigureServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICartService, CartManager>();
        }

        public static void ConfigureAuthServiceInjection(this IServiceCollection services) =>
            services.AddScoped<IAuthenticationService, AuthenticationManager>();

        public static void ConfigureActionFilter(this IServiceCollection services)
        {
            services.AddSingleton<LogFilterAttribute>();
            services.AddSingleton<ValidationFilterAttribute>();
        }

        public static void ConfigureJWT(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = tokenValidationParameters
                );

        }

        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("EcommerceCorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Pagination-Detail"));
            });
        }
    }
}
