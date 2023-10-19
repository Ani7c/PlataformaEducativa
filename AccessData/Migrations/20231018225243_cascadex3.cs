using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class cascadex3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_PosiblesEcosistemas_Especies__especiesId",
                table: "PosiblesEcosistemas");

            migrationBuilder.AddForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PosiblesEcosistemas_Especies__especiesId",
                table: "PosiblesEcosistemas",
                column: "_especiesId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_PosiblesEcosistemas_Especies__especiesId",
                table: "PosiblesEcosistemas");

            migrationBuilder.AddForeignKey(
                name: "FK_PosiblesEcosistemas_Ecosistemas__ecosistemasIdEcosistema",
                table: "PosiblesEcosistemas",
                column: "_ecosistemasIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PosiblesEcosistemas_Especies__especiesId",
                table: "PosiblesEcosistemas",
                column: "_especiesId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
