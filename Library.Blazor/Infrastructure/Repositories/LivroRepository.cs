using Library.Blazor.Domain.Entities;
using Library.Blazor.Domain.Interfaces;
using Library.Blazor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Blazor.Infrastructure.Repositories;

public class LivroRepository : ILivroRepository
{

    private readonly BibliotecaDbContext _context;

    public LivroRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> ObterTodosAsync()
    {
        return await _context.Livros.AsNoTracking().ToListAsync();
    }

    public async Task<Livro?> ObterPorIdAsync(int id)
    {
        return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(livro => livro.Id == id);
    }

    public async Task  AdicionarAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Livro livro)
    {
        _context.Livros.Update(livro);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Livro livro)
    {
        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
    }

}
