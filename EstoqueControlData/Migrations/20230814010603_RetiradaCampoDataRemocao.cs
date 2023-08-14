using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueControlData.Migrations
{
    /// <inheritdoc />
    public partial class RetiradaCampoDataRemocao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRemocao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataRemocao",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataRemocao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataRemocao",
                table: "Categorias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRemocao",
                table: "Produtos",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRemocao",
                table: "Fornecedores",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRemocao",
                table: "Enderecos",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRemocao",
                table: "Categorias",
                type: "DATETIME",
                nullable: true);
        }
    }
}
