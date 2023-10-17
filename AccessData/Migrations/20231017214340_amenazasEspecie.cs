using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class amenazasEspecie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_especiesTempId",
                table: "Ecosistema_Especie",
                newName: "_especiesTempId1");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre del ecosistema",
                table: "Ecosistemas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Especies_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId",
                principalTable: "Especies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Especies_EspecieMarinaId",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId",
                table: "Amenazas");

            migrationBuilder.RenameColumn(
                name: "_especiesTempId1",
                table: "Ecosistema_Especie",
                newName: "_especiesTempId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre del ecosistema",
                table: "Ecosistemas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
