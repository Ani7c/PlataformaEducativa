using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class estadoCons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValorMax",
                table: "EstadosDeConservacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorMin",
                table: "EstadosDeConservacion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorMax",
                table: "EstadosDeConservacion");

            migrationBuilder.DropColumn(
                name: "ValorMin",
                table: "EstadosDeConservacion");
        }
    }
}
