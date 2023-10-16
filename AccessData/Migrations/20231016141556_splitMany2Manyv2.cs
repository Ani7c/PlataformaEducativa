using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class splitMany2Manyv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_EstadosDeConservacion_IdEstadoConservacion",
                table: "Ecosistemas");

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

            migrationBuilder.RenameColumn(
                name: "IdEstadoConservacion",
                table: "Ecosistemas",
                newName: "EstadoConservacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Ecosistemas_IdEstadoConservacion",
                table: "Ecosistemas",
                newName: "IX_Ecosistemas_EstadoConservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_EstadosDeConservacion_EstadoConservacionId",
                table: "Ecosistemas",
                column: "EstadoConservacionId",
                principalTable: "EstadosDeConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_EstadosDeConservacion_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId",
                principalTable: "EstadosDeConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_EstadosDeConservacion_EstadoConservacionId",
                table: "Ecosistemas");

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

            migrationBuilder.RenameColumn(
                name: "EstadoConservacionId",
                table: "Ecosistemas",
                newName: "IdEstadoConservacion");

            migrationBuilder.RenameIndex(
                name: "IX_Ecosistemas_EstadoConservacionId",
                table: "Ecosistemas",
                newName: "IX_Ecosistemas_IdEstadoConservacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_EstadosDeConservacion_IdEstadoConservacion",
                table: "Ecosistemas",
                column: "IdEstadoConservacion",
                principalTable: "EstadosDeConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_EstadosDeConservacion_IdEstadoConservacion",
                table: "Especies",
                column: "IdEstadoConservacion",
                principalTable: "EstadosDeConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
