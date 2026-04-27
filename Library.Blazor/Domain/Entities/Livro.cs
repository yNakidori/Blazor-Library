using Azure.Core;
using Library.Blazor.Domain.Enums;

namespace Library.Blazor.Domain.Entities
{

    public class Livro
    {
        public int Id { get; private set; }

        // Características essenciais do livro
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string? Descricao { get; private set; }
        
        public string Idioma { get; private set; } = "PT-BR";

        public DateOnly? DataPublicacao { get; private set; }

        // Não é necessario já possuir o livro em sí para cadastrar
        public string? CapaUrl { get; private set; }
        public string? ArquivoLocal { get; private set; }

        public StatusLeitura StatusLeitura { get; private set; } = StatusLeitura.NaoLido;
        public string? NotaPessoal { get; private set; }
        public bool Favorito {  get; private set; } = false;
        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

        public Livro(string titulo,string autor)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título é obrigatório.");

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor é obrigatório.");

            Titulo = titulo.Trim();
            Autor = autor.Trim();
        }

        public void MarcarFavorito() => Favorito = true;

        public void RemoverFAvorito() => Favorito = false;

        public void AlterarStatus(StatusLeitura status) => StatusLeitura = status;

        public void AdicionarNota(string nota) => NotaPessoal = nota;

        // Esse trecho abaixo seria a forma tradicional de escrever os métodos, mas como eles são simples, podemos usar a sintaxe de expressão para deixá-los mais concisos e legíveis. (expression-bodied) 

        //public void MarcarFavorito()
        //{
        //    Favorito = true;
        //}

        //public void RemoverFavorito()
        //{
        //    Favorito = false;
        //}

        //public void AlterarStatus(StatusLeitura status)
        //{
        //    StatusLeitura = status;
        //}

        //public void AdicionarNota(string nota)
        //{
        //    NotaPessoal = nota;
        //}

    }
}