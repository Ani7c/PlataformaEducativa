using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class agregarIDpaisaEcosistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pais_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_Pais_EcosistemaMarinoIdEcosistema",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Pais");

            migrationBuilder.AddColumn<string>(
                name: "codPais",
                table: "Ecosistemas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_codPais",
                table: "Ecosistemas",
                column: "codPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_Pais_codPais",
                table: "Ecosistemas",
                column: "codPais",
                principalTable: "Pais",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_Pais_codPais",
                table: "Ecosistemas");

            migrationBuilder.DropIndex(
                name: "IX_Ecosistemas_codPais",
                table: "Ecosistemas");

            migrationBuilder.DropColumn(
                name: "codPais",
                table: "Ecosistemas");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaMarinoIdEcosistema",
                table: "Pais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pais_EcosistemaMarinoIdEcosistema",
                table: "Pais",
                column: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Pais_Ecosistemas_EcosistemaMarinoIdEcosistema",
                table: "Pais",
                column: "EcosistemaMarinoIdEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "IdEcosistema");
        }
    }
}
