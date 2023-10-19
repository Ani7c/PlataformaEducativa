using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcosistemasMarinos.Entidades;
using Ecosistemas_Marinos.Entidades;

namespace AccessData.EntityFramework
{
    public class EcosistemaMarinoContext : DbContext
    {
        #region DbSets
        public DbSet<EcosistemaMarino> Ecosistemas { get; set; }
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<EspecieMarina> Especies { get; set; }
        public DbSet<EstadoConservacion> EstadosDeConservacion { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<ControlDeCambios> ControlDeCambios { get; set; }


        #endregion

        #region Configuracion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=prueba;Integrated Security=true;");
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<EcosistemaMarino>()
                .HasMany(em => em._especies)
                .WithMany(ecosistema => ecosistema._ecosistemas)
                .UsingEntity<Dictionary<string, string>>(
                    "RealmenteHabita",
                    em => em.HasOne<EspecieMarina>().WithMany().OnDelete(DeleteBehavior.Restrict),
                 ecosistema => ecosistema.HasOne<EcosistemaMarino>().WithMany().OnDelete(DeleteBehavior.Restrict)
                ); 


            modelBuilder.Entity<EspecieMarina>()
            .HasMany(es => es._ecosistemas)
            .WithMany(especie => especie._especies)
            .UsingEntity<Dictionary<string, string>>(
                "PosiblesEcosistemas",
                es => es.HasOne<EcosistemaMarino>().WithMany().OnDelete(DeleteBehavior.Cascade),
                especie => especie.HasOne<EspecieMarina>().WithMany().OnDelete(DeleteBehavior.Restrict));

        }

    }
}
