using Library.Blazor.Domain.Entities;
using Library.Blazor.Infrastructure.Data;
using Library.Blazor.Application.DTOs.Livros;
using Microsoft.EntityFrameworkCore;

namespace Library.Blazor.Domain.Services;

public class LivroService
{

    private readonly BibliotecaDbContext _context;

    public LivroService(BibliotecaDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task AdicionarAsync(CriarLivroDto dto)
    {
        var livro = new Livro(dto.Titulo, dto.Autor);
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
    }

    // Read
    public async Task<List<Livro>> ObterTodosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    // Update (emprestar)
    public async Task EmprestarAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return;

        livro.Emprestar();
        await _context.SaveChangesAsync();
    }

    // Update (devolver)
    public async Task DevolverAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return;

        livro.Devolver();
        await _context.SaveChangesAsync();
    }

    // Update (editar)
    public async Task AtualizarAsync(AtualizarLivroDto dto)
    {
        var livro = await _context.Livros.FindAsync(dto.Id);
        if (livro == null) return;

        livro.AtualizarDados(dto.Titulo, dto.Autor);
        await _context.SaveChangesAsync();
    }

    // Delete
    public async Task RemoverAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
    }

}