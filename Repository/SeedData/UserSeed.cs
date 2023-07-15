using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SeedData
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var users = new List<User>()
            {
                new User 
                {
                    Id = 1,
                    FirstName = "Kullanici1",
                    LastName = "user1",
                    UserName = "kullanici1",
                    NormalizedUserName = "KULLANICI1",
                    Email = "kullanici1@admin.com",
                    NormalizedEmail = "kullanici1@GMAIL.COM",
                    PhoneNumber = "+9053399999991",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    
                },
                new User 
                {
                    Id = 2,
                    FirstName = "Kullanici2",
                    LastName = "user2",
                    UserName = "kullanici2",
                    NormalizedUserName = "KULLANICI2",
                    Email = "kullanici2@admin.com",
                    NormalizedEmail = "kullanici2@GMAIL.COM",
                    PhoneNumber = "+9053399999991",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now
                }
            };
            users[0].PasswordHash = CreatePasswordHash(users[0], "kullanici1");
            users[1].PasswordHash = CreatePasswordHash(users[1], "kullanici2");

            builder.HasData(users);
        }
        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
