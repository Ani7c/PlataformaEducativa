using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosDeConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangoDeSeguridad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosDeConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    CodAlpha = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.CodAlpha);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombredelecosistema = table.Column<string>(name: "Nombre del ecosistema", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UbicacionGeografica_Latitud = table.Column<double>(type: "float", nullable: false),
                    UbicacionGeografica_Longitud = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    PaisCodAlpha = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadosDeConservacion_id",
                        column: x => x.id,
                        principalTable: "EstadosDeConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_Paises_PaisCodAlpha",
                        column: x => x.PaisCodAlpha,
                        principalTable: "Paises",
                        principalColumn: "CodAlpha");
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombrecientifico = table.Column<string>(name: "Nombre cientifico", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombrevulgar = table.Column<string>(name: "Nombre vulgar", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rangoPeso_PesoMin = table.Column<double>(type: "float", nullable: false),
                    rangoPeso_PesoMax = table.Column<double>(type: "float", nullable: false),
                    rangoLongitud_LongitudMin = table.Column<double>(type: "float", nullable: false),
                    rangoLongitud_LongitudMax = table.Column<double>(type: "float", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_Ecosistemas_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Especies_EstadosDeConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadosDeConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peligrosidad = table.Column<int>(type: "int", nullable: false),
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: true),
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenazas_Ecosistemas_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amenazas_Especies_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EcosistemaMarinoId",
                table: "Amenazas",
                column: "EcosistemaMarinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_id",
                table: "Ecosistemas",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_Nombre del ecosistema",
                table: "Ecosistemas",
                column: "Nombre del ecosistema",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_PaisCodAlpha",
                table: "Ecosistemas",
                column: "PaisCodAlpha");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EcosistemaMarinoId",
                table: "Especies",
                column: "EcosistemaMarinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_Nombre cientifico",
                table: "Especies",
                column: "Nombre cientifico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especies_Nombre vulgar",
                table: "Especies",
                column: "Nombre vulgar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Alias",
                table: "usuarios",
                column: "Alias",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "EstadosDeConservacion");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
