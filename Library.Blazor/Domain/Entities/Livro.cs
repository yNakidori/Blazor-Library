namespace Library.Blazor.Domain.Entities
{
    public class Livro
    {
        public int Id { get; protected set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public bool Disponivel { get; private set; } = true;


        // Construtor vazio para o Entity Framework
        private Livro() { }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }

        public void Emprestar()
        {
            Disponivel = false;
        }

        public void Devolver()
        {
            Disponivel = true;
        }

    }
}
