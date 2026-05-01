using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class UltimaLeituraEm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmLeitura",
                table: "Livros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaLeituraEm",
                table: "Livros",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmLeitura",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "UltimaLeituraEm",
                table: "Livros");
        }
    }
}
