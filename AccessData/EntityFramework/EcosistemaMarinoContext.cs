﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcosistemasMarinos.Entidades;
using Ecosistemas_Marinos.Entidades;

namespace AccessData.EntityFramework
{
    public class EcosistemaMarinoContext:DbContext
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
                .WithMany(especie => especie._ecosistemas)
                .UsingEntity<Dictionary<string, string>>(
                    "Ecosistema_Especie",
                    em => em.HasOne<EspecieMarina>().WithMany().HasForeignKey().OnDelete(DeleteBehavior.NoAction)
                   // ecosistema => ecosistema.HasOne<EcosistemaMarino>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );

            //modelBuilder.Entity<EspecieMarina>()
            //    .HasMany(es => es._ecosistemas)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, string>>(
            //        "EspeciesHabitanEcosistema",
            //        es => es.HasOne<EcosistemaMarino>().WithMany().OnDelete(DeleteBehavior.Restrict)
            //        especie => especie.HasOne<EspecieMarina>().WithMany().OnDelete(DeleteBehavior.Restrict)
            //    );

      
            //
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
            return base.SaveChanges();
        }



    }
}
