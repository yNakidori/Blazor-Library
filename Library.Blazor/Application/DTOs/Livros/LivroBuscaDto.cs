namespace Library.Blazor.Application.DTOs.Livros
{
    public class LivroBuscaDto
    {
        public string Key { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public int? Ano { get; set; }
        public string CapaUrl { get; set; } = "";
    }
}
