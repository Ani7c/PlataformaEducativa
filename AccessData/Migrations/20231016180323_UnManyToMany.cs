using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class UnManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                table: "Ecosistema_Especie",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
