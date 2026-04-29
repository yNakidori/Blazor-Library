using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCamposArquivoLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CapaUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArquivoUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TamanhoArquivo",
                table: "Livros",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoArquivo",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArquivoUrl",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "TamanhoArquivo",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "TipoArquivo",
                table: "Livros");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CapaUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
