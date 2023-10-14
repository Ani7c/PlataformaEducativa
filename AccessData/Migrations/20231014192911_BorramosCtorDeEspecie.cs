using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class BorramosCtorDeEspecie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especies_EstadosDeConservacion_EstadoConservacionId",
                table: "Especies");

            migrationBuilder.RenameColumn(
                name: "EstadoConservacionId",
                table: "Especies",
                newName: "IdEstadoConservacion");

            migrationBuilder.RenameIndex(
                name: "IX_Especies_EstadoConservacionId",
                table: "Especies",
                newName: "IX_Especies_IdEstadoConservacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_EstadosDeConservacion_IdEstadoConservacion",
                table: "Especies",
                column: "IdEstadoConservacion",
                principalTable: "EstadosDeConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especies_EstadosDeConservacion_IdEstadoConservacion",
                table: "Especies");

            migrationBuilder.RenameColumn(
                name: "IdEstadoConservacion",
                table: "Especies",
                newName: "EstadoConservacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Especies_IdEstadoConservacion",
                table: "Especies",
                newName: "IX_Especies_EstadoConservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_EstadosDeConservacion_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId",
                principalTable: "EstadosDeConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
