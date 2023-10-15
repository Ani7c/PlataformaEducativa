using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class crearBDDotraVez3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Especies_EspecieMarinaId",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId",
                table: "Amenazas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Especies_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId",
                principalTable: "Especies",
                principalColumn: "Id");
        }
    }
}
