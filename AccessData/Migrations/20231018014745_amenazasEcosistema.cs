using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class amenazasEcosistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_ecosistemasTempId",
                table: "Ecosistema_Especie",
                newName: "_ecosistemasTempId1");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EcosistemaMarinoIdEcosistema",
                table: "Amenazas",
                column: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Amenazas",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EcosistemaMarinoIdEcosistema",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Amenazas");

            migrationBuilder.RenameColumn(
                name: "_ecosistemasTempId1",
                table: "Ecosistema_Especie",
                newName: "_ecosistemasTempId");
        }
    }
}
