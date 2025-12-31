using Library.Blazor.Domain.Entities;
using Library.Blazor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Library.Blazor.Domain.Services;

public class LivroService
{
    private readonly BibliotecaDbContext _context;


    public LivroService(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> ObterTodosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task AdicionarAsync(string titulo, string autor)
    {
        var livro = new Livro(titulo, autor);
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
    }

    public async Task EmprestarAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return;

        livro.Emprestar();
        await _context.SaveChangesAsync();
    }

}
