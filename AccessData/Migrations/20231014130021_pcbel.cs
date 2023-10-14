using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class pcbel : Migration
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
                name: "Pais",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    IdEcosistema = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombredelecosistema = table.Column<string>(name: "Nombre del ecosistema", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UbicacionGeografica_Latitud = table.Column<double>(type: "float", nullable: false),
                    UbicacionGeografica_Longitud = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoConservacion = table.Column<int>(type: "int", nullable: false),
                    PaisCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.IdEcosistema);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadosDeConservacion_IdEstadoConservacion",
                        column: x => x.IdEstadoConservacion,
                        principalTable: "EstadosDeConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_Pais_PaisCodigo",
                        column: x => x.PaisCodigo,
                        principalTable: "Pais",
                        principalColumn: "Codigo");
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
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    EcosistemaMarinoIdEcosistema = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_Ecosistemas_EcosistemaMarinoIdEcosistema",
                        column: x => x.EcosistemaMarinoIdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "IdEcosistema");
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
                    IdAmenaza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peligrosidad = table.Column<int>(type: "int", nullable: false),
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.IdAmenaza);
                    table.ForeignKey(
                        name: "FK_Amenazas_Especies_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieMarinaId",
                table: "Amenazas",
                column: "EspecieMarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_IdEstadoConservacion",
                table: "Ecosistemas",
                column: "IdEstadoConservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_PaisCodigo",
                table: "Ecosistemas",
                column: "PaisCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EcosistemaMarinoIdEcosistema",
                table: "Especies",
                column: "EcosistemaMarinoIdEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId");
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
                name: "Pais");
        }
    }
}
