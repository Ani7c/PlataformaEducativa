using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class splitMany2Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie");

            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Especies__especiesId",
                table: "Ecosistema_Especie");

            migrationBuilder.RenameColumn(
                name: "_ecosistemasIdEcosistema",
                table: "Ecosistema_Especie",
                newName: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId",
                table: "Ecosistema_Especie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EspeciesHabitanEcosistema",
                columns: table => new
                {
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: false),
                    _ecosistemasIdEcosistema = table.Column<int>(type: "int", nullable: false),
                    EcosistemaMarinoIdEcosistema = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesHabitanEcosistema", x => new { x.EspecieMarinaId, x._ecosistemasIdEcosistema });
                    table.ForeignKey(
                        name: "FK_EspeciesHabitanEcosistema_Ecosistemas_EcosistemaMarinoIdEcosistema",
                        column: x => x.EcosistemaMarinoIdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "IdEcosistema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EspeciesHabitanEcosistema_Ecosistemas__ecosistemasIdEcosistema",
                        column: x => x._ecosistemasIdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "IdEcosistema",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspeciesHabitanEcosistema_Especies_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistema_Especie_EspecieMarinaId",
                table: "Ecosistema_Especie",
                column: "EspecieMarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesHabitanEcosistema__ecosistemasIdEcosistema",
                table: "EspeciesHabitanEcosistema",
                column: "_ecosistemasIdEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesHabitanEcosistema_EcosistemaMarinoIdEcosistema",
                table: "EspeciesHabitanEcosistema",
                column: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Especies_EspecieMarinaId",
                table: "Ecosistema_Especie",
                column: "EspecieMarinaId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Especies__especiesId",
                table: "Ecosistema_Especie",
                column: "_especiesId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie");

            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Especies_EspecieMarinaId",
                table: "Ecosistema_Especie");

            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Especies__especiesId",
                table: "Ecosistema_Especie");

            migrationBuilder.DropTable(
                name: "EspeciesHabitanEcosistema");

            migrationBuilder.DropIndex(
                name: "IX_Ecosistema_Especie_EspecieMarinaId",
                table: "Ecosistema_Especie");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId",
                table: "Ecosistema_Especie");

            migrationBuilder.RenameColumn(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie",
                newName: "_ecosistemasIdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Especies__especiesId",
                table: "Ecosistema_Especie",
                column: "_especiesId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
