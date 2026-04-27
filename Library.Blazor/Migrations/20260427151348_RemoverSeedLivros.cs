using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class RemoverSeedLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "Livros",
                newName: "Favorito");

            migrationBuilder.AddColumn<string>(
                name: "ArquivoLocal",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapaUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Livros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataPublicacao",
                table: "Livros",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Idioma",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NotaPessoal",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusLeitura",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArquivoLocal",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "CapaUrl",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DataPublicacao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Idioma",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "NotaPessoal",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "StatusLeitura",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "Favorito",
                table: "Livros",
                newName: "Disponivel");

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "Disponivel", "Titulo" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", true, "O Hobbit" },
                    { 2, "George Orwell", true, "1984" },
                    { 3, "Ray Bradbury", true, "Fahrenheit 451" }
                });
        }
    }
}
