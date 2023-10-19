using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class cascadex4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita");

            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Especies_EspecieMarinaId",
                table: "RealmenteHabita");

            migrationBuilder.AddForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Especies_EspecieMarinaId",
                table: "RealmenteHabita",
                column: "EspecieMarinaId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita");

            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Especies_EspecieMarinaId",
                table: "RealmenteHabita");

            migrationBuilder.AddForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Especies_EspecieMarinaId",
                table: "RealmenteHabita",
                column: "EspecieMarinaId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
