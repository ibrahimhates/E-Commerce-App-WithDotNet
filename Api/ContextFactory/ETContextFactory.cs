using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Api.ContextFactory
{
    public class ETContextFactory :
        IDesignTimeDbContextFactory<ETContext>
    {
        public ETContext CreateDbContext(string[] args)
        {
            // Configure and add appsettings.json file
            var configure = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connnectionString from appsettings.json
            var conn = configure.GetConnectionString("sqlConnection");

            // I Gave DbContextOptionsBuilder the connectionString
            // And I said where the migrations will form
            var builder = new DbContextOptionsBuilder<ETContext>()
                .UseSqlServer(conn,p => p.MigrationsAssembly("Api"));

            // Create new Etcontext and return it
            return new ETContext(builder.Options);
        }
    }
}
