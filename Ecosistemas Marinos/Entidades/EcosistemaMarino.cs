using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
  //  [Index(nameof(Nombre), IsUnique = true)]
    [PrimaryKey(nameof(IdEcosistema))]
    public class EcosistemaMarino : IValidable
    { 
        public int IdEcosistema;

        [Required(ErrorMessage = "El nombre del ecosistema es requerido"), Column("Nombre del ecosistema")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Largo del nombre: entre 2 y 50 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Ubicacion geografica")]
        public UbicacionGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public string Caracteristicas { get; set; }

        [ForeignKey(nameof(EstadoConservacion))] public int IdEstadoConservacion { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }

        [ForeignKey(nameof(Pais))] public string codPais { get; set; }
        public Pais Pais { get; set; }

        //public List<Amenaza> _amenazas { get; set; }


        public List<EspecieMarina> _especies { get; set; }

        //  public List<EspecieMarina> _especiesQueHabitan { get; set; }

        [DisplayName("Imagen")]
        public string ImgEcosistema { get; set; }

        
        public EcosistemaMarino() 
        {
            //_amenazas = new List<Amenaza>();
        }


        public void EsValido()
        {
            if(Nombre.Length < 2 || Nombre.Length > 50)
            {
                throw new EcosystemException("Nombre no valido");
            }
        }

       
    }
}
