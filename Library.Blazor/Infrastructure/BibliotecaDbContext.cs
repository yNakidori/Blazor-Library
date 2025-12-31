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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().HasData(
                new { Id = 1, Titulo = "O Hobbit", Autor = "J.R.R. Tolkien", Disponivel = true },
                new { Id = 2, Titulo = "1984", Autor = "George Orwell", Disponivel = true },
                new { Id = 3, Titulo = "Fahrenheit 451", Autor = "Ray Bradbury", Disponivel = true }
            );
        }

    }
}

