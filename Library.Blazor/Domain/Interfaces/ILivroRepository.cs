using Library.Blazor.Domain.Entities;

namespace Library.Blazor.Domain.Interfaces
{
    public interface ILivroRepository
    {
        // Consultas
        Task<List<Livro>> ObterTodosAsync();
        Task<Livro?> ObterPorIdAsync(int id);
        // Comandos
        Task AdicionarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
        Task RemoverAsync(Livro livro);
    }
}