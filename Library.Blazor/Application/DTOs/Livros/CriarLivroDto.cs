using System.ComponentModel.DataAnnotations;

namespace Library.Blazor.Application.DTOs.Livros
{
    public class CriarLivroDto
    {
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Titulo { get; set; } = "";
        [Required(ErrorMessage = "Autor é obrigatório")]
        public string Autor { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Idioma { get; set; } = "";
        public DateOnly? DataPublicacao { get; set; }
        public string? CapaUrl { get; set; }
    }
}
