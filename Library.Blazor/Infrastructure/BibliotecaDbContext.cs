using Library.Blazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Blazor.Infrastructure.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options)

        {
        }

        public DbSet<Livro> Livros => Set<Livro>();
    }
}