using System.Text.Json;
using Library.Blazor.Application.DTOs.Livros;

namespace Library.Blazor.Infrastructure.Services
{
    public class OpenLibraryService
    {
        private readonly HttpClient _http;

        public OpenLibraryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LivroMetadataDto?> BuscarPorTituloAsync(string titulo)
        {
            var url =
                $"https://openlibrary.org/search.json?title={Uri.EscapeDataString(titulo)}";

            var json = await _http.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);

            var docs = doc.RootElement.GetProperty("docs");

            if (docs.GetArrayLength() == 0)
                return null;

            var livro = docs[0];

            var tituloRetorno =
                livro.TryGetProperty("title", out var t)
                ? t.GetString() ?? ""
                : "";

            var autor =
                livro.TryGetProperty("author_name", out var a)
                ? a[0].GetString() ?? ""
                : "";

            string capa = "";

            if (livro.TryGetProperty("cover_i", out var c))
            {
                var id = c.GetInt32();
                capa = $"https://covers.openlibrary.org/b/id/{id}-L.jpg";
            }

            return new LivroMetadataDto
            {
                Titulo = tituloRetorno,
                Autor = autor,
                CapaUrl = capa
            };     

        }

        public async Task<LivroMetadataDto?> BuscarDetalhesAsync(string key)
        {
            var url = $"https://openlibrary.org{key}.json";

            var json = await _http.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);

            var root = doc.RootElement;

            var titulo =
                root.TryGetProperty("title", out var t)
                ? t.GetString() ?? ""
                : "";

            string descricao = "Sem descrição disponível, você ainda pode incluir uma descrição manualmente se quiser";


            if (root.TryGetProperty("description", out var d))
            {
                if (d.ValueKind == JsonValueKind.String)
                    descricao = d.GetString() ?? descricao;

                else if (d.ValueKind == JsonValueKind.Object &&
                         d.TryGetProperty("value", out var val))
                    descricao = val.GetString() ?? descricao;
            }

            string idioma = "";

            if (root.TryGetProperty("languages", out var langs) &&
                langs.GetArrayLength() > 0)
            {
                idioma = "EN";
            }

            DateOnly? dataPublicacao = null;

            if (root.TryGetProperty("created", out var created) && created.TryGetProperty("value", out var createdVal))
            {
                if (DateTime.TryParse(createdVal.GetString(), out var dt))
                {
                    dataPublicacao = DateOnly.FromDateTime(dt);
                }
            }

            return new LivroMetadataDto
            {
                Titulo = titulo,
                Autor = "",
                Descricao = descricao,
                Idioma = idioma,
                DataPublicacao = dataPublicacao,
                CapaUrl = ""
            };

        }

        public async Task<List<LivroBuscaDto>> BuscarMultiplosAsync(string titulo)
        {
            var url =
                $"https://openlibrary.org/search.json?title={Uri.EscapeDataString(titulo)}";

            var json = await _http.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);

            var docs = doc.RootElement.GetProperty("docs");

            var lista = new List<LivroBuscaDto>();

            foreach (var item in docs.EnumerateArray().Take(5))
            {
                var dto = new LivroBuscaDto
                {
                    Key = item.TryGetProperty("key", out var k)
                        ? k.GetString() ?? ""
                        : "",

                    Titulo = item.TryGetProperty("title", out var t)
                    ? t.GetString() ?? ""
                    : "",

                    Autor = item.TryGetProperty("author_name", out var a)
                    ? a[0].GetString() ?? ""
                    : "",

                    Ano = item.TryGetProperty("first_publish_year", out var y)
                    ? y.GetInt32()
                    : null,

                    CapaUrl = item.TryGetProperty("cover_i", out var c)
                    ? $"https://covers.openlibrary.org/b/id/{c.GetInt32()}-M.jpg"
                    : ""
                };
                lista.Add(dto);
            }

            return lista;

        }

      

    }
}
