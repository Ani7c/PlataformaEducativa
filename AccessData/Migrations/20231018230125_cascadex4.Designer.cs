﻿// <auto-generated />
using System;
using AccessData.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccessData.Migrations
{
    [DbContext(typeof(EcosistemaMarinoContext))]
    [Migration("20231018230125_cascadex4")]
    partial class cascadex4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Amenaza", b =>
                {
                    b.Property<int>("IdAmenaza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAmenaza"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EcosistemaMarinoIdEcosistema")
                        .HasColumnType("int");

                    b.Property<int?>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.Property<int>("Peligrosidad")
                        .HasColumnType("int");

                    b.HasKey("IdAmenaza");

                    b.HasIndex("EcosistemaMarinoIdEcosistema");

                    b.HasIndex("EspecieMarinaId");

                    b.ToTable("Amenazas");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.Property<int>("IdEcosistema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEcosistema"));

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstadoConservacion")
                        .HasColumnType("int");

                    b.Property<string>("ImgEcosistema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre del ecosistema");

                    b.Property<string>("codPais")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdEcosistema");

                    b.HasIndex("IdEstadoConservacion");

                    b.HasIndex("codPais");

                    b.ToTable("Ecosistemas");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstadoConservacion")
                        .HasColumnType("int");

                    b.Property<string>("ImgEspecie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCientifico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre cientifico");

                    b.Property<string>("NombreVulgar")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre vulgar");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoConservacion");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EstadoConservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RangoDeSeguridad")
                        .HasColumnType("int");

                    b.Property<int>("ValorMax")
                        .HasColumnType("int");

                    b.Property<int>("ValorMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("EstadosDeConservacion");
                });

            modelBuilder.Entity("Ecosistemas_Marinos.Entidades.Configuracion", b =>
                {
                    b.Property<string>("NombreAtributo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TopeInferior")
                        .HasColumnType("int");

                    b.Property<int>("TopeSuperior")
                        .HasColumnType("int");

                    b.HasKey("NombreAtributo");

                    b.ToTable("Configuraciones");
                });

            modelBuilder.Entity("Ecosistemas_Marinos.Entidades.ControlDeCambios", b =>
                {
                    b.Property<int>("IdCambios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCambios"));

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEntidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEntidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCambios");

                    b.ToTable("ControlDeCambios");
                });

            modelBuilder.Entity("Ecosistemas_Marinos.Entidades.Pais", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Ecosistemas_Marinos.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("PosiblesEcosistemas", b =>
                {
                    b.Property<int>("_ecosistemasIdEcosistema")
                        .HasColumnType("int");

                    b.Property<int>("_especiesId")
                        .HasColumnType("int");

                    b.HasKey("_ecosistemasIdEcosistema", "_especiesId");

                    b.HasIndex("_especiesId");

                    b.ToTable("PosiblesEcosistemas");
                });

            modelBuilder.Entity("RealmenteHabita", b =>
                {
                    b.Property<int>("_ecosistemasTempId1")
                        .HasColumnType("int");

                    b.Property<int>("_especiesTempId1")
                        .HasColumnType("int");

                    b.Property<int>("EcosistemaMarinoIdEcosistema")
                        .HasColumnType("int");

                    b.Property<int>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.HasKey("_ecosistemasTempId1", "_especiesTempId1");

                    b.HasIndex("EcosistemaMarinoIdEcosistema");

                    b.HasIndex("EspecieMarinaId");

                    b.ToTable("RealmenteHabita");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Amenaza", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany("_amenazas")
                        .HasForeignKey("EcosistemaMarinoIdEcosistema");

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany("_amenazas")
                        .HasForeignKey("EspecieMarinaId");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("IdEstadoConservacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecosistemas_Marinos.Entidades.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("codPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Ecosistemas_Marinos.ValueObjects.UbicacionGeografica", "UbicacionGeografica", b1 =>
                        {
                            b1.Property<int>("EcosistemaMarinoIdEcosistema")
                                .HasColumnType("int");

                            b1.Property<double>("Latitud")
                                .HasColumnType("float");

                            b1.Property<double>("Longitud")
                                .HasColumnType("float");

                            b1.HasKey("EcosistemaMarinoIdEcosistema");

                            b1.ToTable("Ecosistemas");

                            b1.WithOwner()
                                .HasForeignKey("EcosistemaMarinoIdEcosistema");
                        });

                    b.Navigation("EstadoConservacion");

                    b.Navigation("Pais");

                    b.Navigation("UbicacionGeografica")
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("IdEstadoConservacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Ecosistemas_Marinos.ValueObjects.Longitud", "rangoLongitud", b1 =>
                        {
                            b1.Property<int>("EspecieMarinaId")
                                .HasColumnType("int");

                            b1.Property<double>("LongitudMax")
                                .HasColumnType("float");

                            b1.Property<double>("LongitudMin")
                                .HasColumnType("float");

                            b1.HasKey("EspecieMarinaId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieMarinaId");
                        });

                    b.OwnsOne("Ecosistemas_Marinos.ValueObjects.Peso", "rangoPeso", b1 =>
                        {
                            b1.Property<int>("EspecieMarinaId")
                                .HasColumnType("int");

                            b1.Property<double>("PesoMax")
                                .HasColumnType("float");

                            b1.Property<double>("PesoMin")
                                .HasColumnType("float");

                            b1.HasKey("EspecieMarinaId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieMarinaId");
                        });

                    b.Navigation("EstadoConservacion");

                    b.Navigation("rangoLongitud")
                        .IsRequired();

                    b.Navigation("rangoPeso")
                        .IsRequired();
                });

            modelBuilder.Entity("PosiblesEcosistemas", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany()
                        .HasForeignKey("_ecosistemasIdEcosistema")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany()
                        .HasForeignKey("_especiesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("RealmenteHabita", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany()
                        .HasForeignKey("EcosistemaMarinoIdEcosistema")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany()
                        .HasForeignKey("EspecieMarinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.Navigation("_amenazas");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.Navigation("_amenazas");
                });
#pragma warning restore 612, 618
        }
    }
}
