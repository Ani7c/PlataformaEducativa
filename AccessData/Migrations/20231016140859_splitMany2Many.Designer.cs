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
    [Migration("20231016140859_splitMany2Many")]
    partial class splitMany2Many
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecosistema_Especie", b =>
                {
                    b.Property<int>("EcosistemaMarinoIdEcosistema")
                        .HasColumnType("int");

                    b.Property<int>("_especiesId")
                        .HasColumnType("int");

                    b.Property<int?>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemaMarinoIdEcosistema", "_especiesId");

                    b.HasIndex("EspecieMarinaId");

                    b.HasIndex("_especiesId");

                    b.ToTable("Ecosistema_Especie");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Amenaza", b =>
                {
                    b.Property<int>("IdAmenaza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAmenaza"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peligrosidad")
                        .HasColumnType("int");

                    b.HasKey("IdAmenaza");

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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangoDeSeguridad")
                        .HasColumnType("int");

                    b.HasKey("Id");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("EspeciesHabitanEcosistema", b =>
                {
                    b.Property<int>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.Property<int>("_ecosistemasIdEcosistema")
                        .HasColumnType("int");

                    b.Property<int?>("EcosistemaMarinoIdEcosistema")
                        .HasColumnType("int");

                    b.HasKey("EspecieMarinaId", "_ecosistemasIdEcosistema");

                    b.HasIndex("EcosistemaMarinoIdEcosistema");

                    b.HasIndex("_ecosistemasIdEcosistema");

                    b.ToTable("EspeciesHabitanEcosistema");
                });

            modelBuilder.Entity("Ecosistema_Especie", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany()
                        .HasForeignKey("EcosistemaMarinoIdEcosistema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany()
                        .HasForeignKey("EspecieMarinaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany()
                        .HasForeignKey("_especiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.Navigation("EstadoConservacion");
                });

            modelBuilder.Entity("EspeciesHabitanEcosistema", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany()
                        .HasForeignKey("EcosistemaMarinoIdEcosistema")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany()
                        .HasForeignKey("EspecieMarinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany()
                        .HasForeignKey("_ecosistemasIdEcosistema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
