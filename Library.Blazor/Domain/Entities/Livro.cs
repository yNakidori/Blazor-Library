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
        public string Descricao { get; private set; } = string.Empty;
        
        public string Idioma { get; private set; } = "PT-BR";

        public DateOnly? DataPublicacao { get; private set; }

        // Não é necessario já possuir o livro em sí para cadastrar
        public string CapaUrl { get; private set; } = string.Empty;
        public string? ArquivoLocal { get; private set; }

        public StatusLeitura StatusLeitura { get; private set; } = StatusLeitura.NaoLido;
        public string? NotaPessoal { get; private set; }
        public bool Favorito {  get; private set; } = false;
        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;
        public string? ArquivoUrl { get; private set; }
        public string? TipoArquivo { get; private set; }
        public long? TamanhoArquivo { get; private set; }

        public Livro(string titulo,string autor)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título é obrigatório.");

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor é obrigatório.");

            Titulo = titulo.Trim();
            Autor = autor.Trim();
        }

        public void AtualizarDados(string titulo, string autor, string? descricao, string? idioma, DateOnly? dataPublicacao, string? capaUrl)
        {
            Titulo = titulo;
            Autor = autor;
            Descricao = descricao;
            Idioma = idioma;
            DataPublicacao = dataPublicacao;
            CapaUrl = capaUrl;
        }

        public void AlternarFavorito()
        {
            Favorito = !Favorito;
        }

        public void AlterarStatus(StatusLeitura status) => StatusLeitura = status;

        public void AdicionarNota(string nota) => NotaPessoal = nota;


        public void DefinirCapa(string? capaUrl)
        {
            CapaUrl = capaUrl;
        }

        public void DefinirDescricao(string? descricao)
        {
            Descricao = descricao;
        }

        public void DefinirIdioma(string idioma)
        {
            Idioma = idioma;
        }

        public void DefinirDataPublicacao(DateOnly? data)
        {
            DataPublicacao = data;
        }

        public void DefinirArquivo(string caminho, string tipo, long tamanho)
        {
            ArquivoUrl = caminho;
            TipoArquivo = tipo;
            TamanhoArquivo = tamanho;
        }
    }
}