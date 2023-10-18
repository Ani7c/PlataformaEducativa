using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class pesoYlongitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "EstadosDeConservacion",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "rangoLongitud_LongitudMax",
                table: "Especies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rangoLongitud_LongitudMin",
                table: "Especies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rangoPeso_PesoMax",
                table: "Especies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rangoPeso_PesoMin",
                table: "Especies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_EstadosDeConservacion_Nombre",
                table: "EstadosDeConservacion",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EstadosDeConservacion_Nombre",
                table: "EstadosDeConservacion");

            migrationBuilder.DropColumn(
                name: "rangoLongitud_LongitudMax",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "rangoLongitud_LongitudMin",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "rangoPeso_PesoMax",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "rangoPeso_PesoMin",
                table: "Especies");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "EstadosDeConservacion",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
