namespace Library.Blazor.Domain.Entities
{
    public class Livro
    {
        public int Id { get; protected set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public bool Disponivel { get; private set; } 


        // Construtor vazio para o Entity Framework
        private Livro() { }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
            Disponivel = true;
        }

        public void Emprestar()
        {
            if (!Disponivel)
                throw new InvalidOperationException("Livro já emprestado");

            Disponivel = false;
        }

        public void Devolver()
        {
            Disponivel = true;
        }

        public void AtualizarDados(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }

    }
}
