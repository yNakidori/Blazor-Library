namespace Library.Blazor.Application.DTOs.Livros
{
    public class LivroMetadataDto
    {
        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Idioma { get; set; } = "";
        public DateOnly? DataPublicacao { get; set; }
        public string CapaUrl { get; set; } = "";
    }
}

