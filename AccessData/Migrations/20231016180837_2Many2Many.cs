using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class _2Many2Many : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ecosistema_Especie",
                table: "Ecosistema_Especie");

            migrationBuilder.RenameColumn(
                name: "_especiesId",
                table: "Ecosistema_Especie",
                newName: "EspecieMarinaId");

            migrationBuilder.RenameColumn(
                name: "_ecosistemasIdEcosistema",
                table: "Ecosistema_Especie",
                newName: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.RenameIndex(
                name: "IX_Ecosistema_Especie__especiesId",
                table: "Ecosistema_Especie",
                newName: "IX_Ecosistema_Especie_EspecieMarinaId");

            migrationBuilder.AddColumn<int>(
                name: "_ecosistemasTempId",
                table: "Ecosistema_Especie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_especiesTempId",
                table: "Ecosistema_Especie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ecosistema_Especie",
                table: "Ecosistema_Especie",
                columns: new[] { "_ecosistemasTempId", "_especiesTempId" });

            migrationBuilder.CreateTable(
                name: "EspeciesHabitanEcosistema",
                columns: table => new
                {
                    _ecosistemasIdEcosistema = table.Column<int>(type: "int", nullable: false),
                    _especiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesHabitanEcosistema", x => new { x._ecosistemasIdEcosistema, x._especiesId });
                    table.ForeignKey(
                        name: "FK_EspeciesHabitanEcosistema_Ecosistemas__ecosistemasIdEcosistema",
                        column: x => x._ecosistemasIdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "IdEcosistema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EspeciesHabitanEcosistema_Especies__especiesId",
                        column: x => x._especiesId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistema_Especie_EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie",
                column: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesHabitanEcosistema__especiesId",
                table: "EspeciesHabitanEcosistema",
                column: "_especiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Especies_EspecieMarinaId",
                table: "Ecosistema_Especie",
                column: "EspecieMarinaId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropTable(
                name: "EspeciesHabitanEcosistema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ecosistema_Especie",
                table: "Ecosistema_Especie");

            migrationBuilder.DropIndex(
                name: "IX_Ecosistema_Especie_EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie");

            migrationBuilder.DropColumn(
                name: "_ecosistemasTempId",
                table: "Ecosistema_Especie");

            migrationBuilder.DropColumn(
                name: "_especiesTempId",
                table: "Ecosistema_Especie");

            migrationBuilder.RenameColumn(
                name: "EspecieMarinaId",
                table: "Ecosistema_Especie",
                newName: "_especiesId");

            migrationBuilder.RenameColumn(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Ecosistema_Especie",
                newName: "_ecosistemasIdEcosistema");

            migrationBuilder.RenameIndex(
                name: "IX_Ecosistema_Especie_EspecieMarinaId",
                table: "Ecosistema_Especie",
                newName: "IX_Ecosistema_Especie__especiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ecosistema_Especie",
                table: "Ecosistema_Especie",
                columns: new[] { "_ecosistemasIdEcosistema", "_especiesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");

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
