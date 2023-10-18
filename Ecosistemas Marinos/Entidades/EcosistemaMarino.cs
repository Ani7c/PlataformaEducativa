using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
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
       
        public string Nombre { get; set; }

        [DisplayName("Ubicacion geografica")]
        public UbicacionGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public string Caracteristicas { get; set; }

        [ForeignKey(nameof(EstadoConservacion))] public int IdEstadoConservacion { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }

        [ForeignKey(nameof(Pais))] public string codPais { get; set; }
        public Pais Pais { get; set; }

        public List<Amenaza> _amenazas { get; set; }


        public List<EspecieMarina> _especies { get; set; }

        //  public List<EspecieMarina> _especiesQueHabitan { get; set; }

        [DisplayName("Imagen")]
        public string ImgEcosistema { get; set; }

        
        public EcosistemaMarino() 
        {
            //_amenazas = new List<Amenaza>();
        }



        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if(Nombre.Length < configuracion.GetTopeInferior("Nombre"))
            {
                throw new EcosystemException("Nombre demasiado corto");
            }
            if (Nombre.Length > configuracion.GetTopeSuperior("Nombre"))
            {
                throw new EcosystemException("Nombre demasiado largo");
            }
        }
    }
}
