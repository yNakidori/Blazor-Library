namespace Library.Blazor.Application.DTOs.Livros
{
    public class AtualizarLivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; }= string.Empty;
        public string? Descricao { get; set; }
        public string? Idioma { get; set; }
        public DateOnly? DataPublicacao { get; set; }
        public string? CapaUrl { get; set; }
    }
}
