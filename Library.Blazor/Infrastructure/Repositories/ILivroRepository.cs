using Library.Blazor.Domain.Entities;

namespace Library.Blazor.Infrastructure.Repositories;


public interface ILivroRepository
{
    Task<List<Livro>> ObterTodosAsync();
    Task AdicionarAsync(Livro livro);
    Task AtualizarAsync(Livro livro);
}
