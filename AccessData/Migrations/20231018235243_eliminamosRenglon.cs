using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class eliminamosRenglon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita");

            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId1",
                table: "RealmenteHabita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealmenteHabita_EspecieMarinaId1",
                table: "RealmenteHabita",
                column: "EspecieMarinaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Especies_EspecieMarinaId1",
                table: "RealmenteHabita",
                column: "EspecieMarinaId1",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita");

            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Especies_EspecieMarinaId1",
                table: "RealmenteHabita");

            migrationBuilder.DropIndex(
                name: "IX_RealmenteHabita_EspecieMarinaId1",
                table: "RealmenteHabita");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId1",
                table: "RealmenteHabita");

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
