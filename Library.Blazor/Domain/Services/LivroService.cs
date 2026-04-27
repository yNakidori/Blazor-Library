using Library.Blazor.Domain.Entities;
using Library.Blazor.Domain.Interfaces;
using Library.Blazor.Application.DTOs.Livros;

namespace Library.Blazor.Domain.Services;

public class LivroService
{

    private readonly ILivroRepository repository;

    public LivroService(ILivroRepository repository)
    {
        this.repository = repository;
    }

    // Create
    public async Task AdicionarAsync(CriarLivroDto dto)
    {
        var livro = new Livro(dto.Titulo, dto.Autor);
        await repository.AdicionarAsync(livro);
    }

    // Read
    public async Task<List<Livro>> ObterTodosAsync()
    {
        return await repository.ObterTodosAsync();
    }

    // Update (editar)
    //public async Task AtualizarAsync(AtualizarLivroDto dto)
    //{
    //    var livro = await _context.Livros.FindAsync(dto.Id);
    //    if (livro == null) return;

    //    livro.AtualizarDados(dto.Titulo, dto.Autor);
    //    await _context.SaveChangesAsync();
    //}

    // Delete
    public async Task RemoverAsync(int id)
    {
        var livro = await repository.ObterPorIdAsync(id);
        if (livro == null) return;

        await repository.RemoverAsync(livro);
    }

}