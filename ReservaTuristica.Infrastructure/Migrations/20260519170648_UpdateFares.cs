using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaTuristica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapacidadBase",
                table: "Tarifas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPersonaAdicional",
                table: "Tarifas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapacidadBase",
                table: "Tarifas");

            migrationBuilder.DropColumn(
                name: "ValorPersonaAdicional",
                table: "Tarifas");
        }
    }
}
