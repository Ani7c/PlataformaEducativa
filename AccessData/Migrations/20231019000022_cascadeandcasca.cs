using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class cascadeandcasca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita");

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita");

            migrationBuilder.AddForeignKey(
                name: "FK_RealmenteHabita_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "RealmenteHabita",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");
        }
    }
}
