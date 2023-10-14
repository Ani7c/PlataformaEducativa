using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class AgregamosMany2Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especies_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Especies");

            migrationBuilder.DropIndex(
                name: "IX_Especies_EcosistemaMarinoIdEcosistema",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Especies");

            migrationBuilder.CreateTable(
                name: "Ecosistema_Especie",
                columns: table => new
                {
                    _ecosistemasIdEcosistema = table.Column<int>(type: "int", nullable: false),
                    _especiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistema_Especie", x => new { x._ecosistemasIdEcosistema, x._especiesId });
                    table.ForeignKey(
                        name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                        column: x => x._ecosistemasIdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "IdEcosistema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ecosistema_Especie_Especies__especiesId",
                        column: x => x._especiesId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistema_Especie__especiesId",
                table: "Ecosistema_Especie",
                column: "_especiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ecosistema_Especie");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Especies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EcosistemaMarinoIdEcosistema",
                table: "Especies",
                column: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Especies",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");
        }
    }
}
