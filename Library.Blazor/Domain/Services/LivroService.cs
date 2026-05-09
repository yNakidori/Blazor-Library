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

    public async Task DefinirArquivoAsync(int id, string url, string tipo, long tamanho)
    {
        var livro = await repository.ObterParaEdicaoAsync(id);

        if (livro == null)
            return;

        livro.DefinirArquivo(url, tipo, tamanho);

        await repository.AtualizarAsync(livro);
    }

    // Delete
    public async Task RemoverAsync(int id)
    {
        var livro = await repository.ObterParaEdicaoAsync(id);
        if (livro == null) return;

        if (!string.IsNullOrWhiteSpace(livro.ArquivoUrl))
        {
            var caminhoFisico = Path.Combine(
                Environment.CurrentDirectory,
                "wwwroot",
                livro.ArquivoUrl.TrimStart('/')
                    .Replace("/", Path.DirectorySeparatorChar.ToString())
            );

            if (File.Exists(caminhoFisico))
            {
                File.Delete(caminhoFisico);
            }
        }

        await repository.RemoverAsync(livro);
    }

    public async Task RemoverArquivoAsync(int id)
    {
        var livro = await repository.ObterParaEdicaoAsync(id);

        if (livro == null)
            return;

        if (!string.IsNullOrWhiteSpace(livro.ArquivoUrl))
        {
            var caminhoFisico = Path.Combine(
                Environment.CurrentDirectory,
                "wwwroot",
                livro.ArquivoUrl.TrimStart('/')
                .Replace("/", Path.DirectorySeparatorChar.ToString())
            );

            if (File.Exists(caminhoFisico))
            {
                File.Delete(caminhoFisico);
            }
        }

        livro.RemoverArquivo();

        await repository.AtualizarAsync(livro);
    }

    public async Task AlternarFavoritoAsync(int id)
    {
        var livro = await repository.ObterParaEdicaoAsync(id);
        if (livro == null) return;

        livro.AlternarFavorito();
        await repository.AtualizarAsync(livro);
    }

    public async Task RegistrarLeituraAsync(int id)
    {
        var livro = await repository.ObterParaEdicaoAsync(id);

        if (livro == null) return;

        livro.RegistrarLeitura();
            
            await repository.AtualizarAsync(livro);
    }
}