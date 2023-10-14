using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class paisComoLista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_Pais_PaisCodigo",
                table: "Ecosistemas");

            migrationBuilder.DropIndex(
                name: "IX_Ecosistemas_PaisCodigo",
                table: "Ecosistemas");

            migrationBuilder.DropColumn(
                name: "PaisCodigo",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PaisCodigo",
                table: "Ecosistemas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_PaisCodigo",
                table: "Ecosistemas",
                column: "PaisCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_Pais_PaisCodigo",
                table: "Ecosistemas",
                column: "PaisCodigo",
                principalTable: "Pais",
                principalColumn: "Codigo");
        }
    }
}
