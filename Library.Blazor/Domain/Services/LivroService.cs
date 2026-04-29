using Library.Blazor.Domain.Entities;
using Library.Blazor.Domain.Interfaces;
using Library.Blazor.Application.DTOs.Livros;
using Microsoft.Identity.Client;

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

        livro.DefinirCapa(dto.CapaUrl);
        livro.DefinirDescricao(dto.Descricao);
        livro.DefinirIdioma(dto.Idioma);
        livro.DefinirDataPublicacao(dto.DataPublicacao);

        await repository.AdicionarAsync(livro);
    }

    // Read
    public async Task<List<Livro>> ObterTodosAsync()
    {
        return await repository.ObterTodosAsync();
    }

    public async Task<Livro?> ObterParaEdicaoAsync(int id)
    {
        return await repository.ObterParaEdicaoAsync(id);
    }

    //Update(editar)
    public async Task AtualizarAsync(AtualizarLivroDto dto)
    {
        var livro = await repository.ObterParaEdicaoAsync(dto.Id);
        if (livro == null) return;

        livro.AtualizarDados(
            dto.Titulo,
            dto.Autor,
            dto.Descricao,
            dto.Idioma,
            dto.DataPublicacao,
            dto.CapaUrl
            );

        await repository.AtualizarAsync(livro);
    }

    // Delete
    public async Task RemoverAsync(int id)
    {
        var livro = await repository.ObterPorIdAsync(id);
        if (livro == null) return;

        await repository.RemoverAsync(livro);
    }

    public async Task AlternarFavoritoAsync(int id)
    {
        var livro = await repository.ObterParaEdicaoAsync(id);
        if (livro == null) return;

        livro.AlternarFavorito();
        await repository.AtualizarAsync(livro);
    }
}