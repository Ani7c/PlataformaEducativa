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
    [Migration("20231014192911_BorramosCtorDeEspecie")]
    partial class BorramosCtorDeEspecie
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

                    b.Property<int?>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.Property<int>("Peligrosidad")
                        .HasColumnType("int");

                    b.HasKey("IdAmenaza");

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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre del ecosistema");

                    b.HasKey("IdEcosistema");

                    b.HasIndex("IdEstadoConservacion");

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

                    b.Property<int?>("EcosistemaMarinoIdEcosistema")
                        .HasColumnType("int");

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

                    b.HasIndex("EcosistemaMarinoIdEcosistema");

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

            modelBuilder.Entity("Ecosistemas_Marinos.Entidades.Pais", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EcosistemaMarinoIdEcosistema")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("EcosistemaMarinoIdEcosistema");

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

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Amenaza", b =>
                {
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

                    b.Navigation("UbicacionGeografica")
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany("_especies")
                        .HasForeignKey("EcosistemaMarinoIdEcosistema");

                    b.HasOne("EcosistemasMarinos.Entidades.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("IdEstadoConservacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoConservacion");
                });

            modelBuilder.Entity("Ecosistemas_Marinos.Entidades.Pais", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany("Paises")
                        .HasForeignKey("EcosistemaMarinoIdEcosistema");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.Navigation("Paises");

                    b.Navigation("_especies");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.Navigation("_amenazas");
                });
#pragma warning restore 612, 618
        }
    }
}
