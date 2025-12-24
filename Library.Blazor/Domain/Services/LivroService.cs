using Library.Blazor.Domain.Entities;
using Library.Blazor.Infrastructure.Repositories;

namespace Library.Blazor.Domain.Services;

public class LivroService
{
    private readonly ILivroRepository _repository;

    public LivroService(ILivroRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Livro>> ListarAsync()
        => _repository.ObterTodosAsync();

    public Task AdicionarAsync(string titulo, string autor)
    {
        var livro = new Livro(titulo, autor);
        return _repository.AdicionarAsync(livro);
    }

    public Task EmprestarAsync(Livro livro)
    {
        livro.Emprestar();
        return _repository.AdicionarAsync(livro);
    }

    public Task DevolverAsync(Livro livro)
    {
        livro.Devolver();
        return _repository.AtualizarAsync(livro);
    }

}
