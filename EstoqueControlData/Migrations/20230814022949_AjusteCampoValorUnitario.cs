using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueControlData.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCampoValorUnitario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUnitario",
                table: "Produtos",
                type: "decimal(12,2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,0)",
                oldPrecision: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUnitario",
                table: "Produtos",
                type: "decimal(2,0)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2);
        }
    }
}
