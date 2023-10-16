using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class CambiamosPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    IdAmenaza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peligrosidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.IdAmenaza);
                });

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
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombrecientifico = table.Column<string>(name: "Nombre cientifico", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombrevulgar = table.Column<string>(name: "Nombre vulgar", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoConservacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_EstadosDeConservacion_IdEstadoConservacion",
                        column: x => x.IdEstadoConservacion,
                        principalTable: "EstadosDeConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    codPais = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        name: "FK_Ecosistemas_Pais_codPais",
                        column: x => x.codPais,
                        principalTable: "Pais",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistema_Especie",
                columns: table => new
                {
                    _ecosistemasIdEcosistema = table.Column<int>(type: "int", nullable: false),
                    _especiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistema_Especie", x => new { x._ecosistemasIdEcosistema, x._especiesId });
                    table.ForeignKey(
                        name: "FK_Ecosistema_Especie_Ecosistemas__ecosistemasIdEcosistema",
                        column: x => x._ecosistemasIdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "IdEcosistema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ecosistema_Especie_Especies__especiesId",
                        column: x => x._especiesId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistema_Especie__especiesId",
                table: "Ecosistema_Especie",
                column: "_especiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_codPais",
                table: "Ecosistemas",
                column: "codPais");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_IdEstadoConservacion",
                table: "Ecosistemas",
                column: "IdEstadoConservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_IdEstadoConservacion",
                table: "Especies",
                column: "IdEstadoConservacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "Ecosistema_Especie");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "EstadosDeConservacion");
        }
    }
}
