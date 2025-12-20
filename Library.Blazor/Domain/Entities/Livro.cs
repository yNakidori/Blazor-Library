namespace Library.Blazor.Domain.Entities
{
    public class Livro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public bool Disponivel { get; private set; }

        public Livro(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = autor;
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

    }
}
