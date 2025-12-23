using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Blazor.Infrastructure.Data
{
    public class BibliotecaDbContextFactory : IDesignTimeDbContextFactory<BibliotecaDbContext>
    {
        public BibliotecaDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BibliotecaDbContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new BibliotecaDbContext(optionsBuilder.Options);

        }
     
    }
}
