using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecosistemas_Marinos.ValueObjects;
using Ecosistemas_Marinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecosistemas_Marinos.Exceptions;
using System.ComponentModel;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcosistemasMarinos.Entidades
{
    //[Index(nameof(NombreCientifico), IsUnique = true)]
    //[Index(nameof(NombreVulgar), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    public class EspecieMarina : IValidable
    {

        public int Id;

        [Required(ErrorMessage = "El nombre de la especie es requerida"), Column("Nombre cientifico")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Largo del nombre: entre 2 y 50 caracteres")]
        public string NombreCientifico { get; set; }


        [Required(ErrorMessage = "El nombre de la especie es requerida"), Column("Nombre vulgar")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Largo del nombre: entre 2 y 50 caracteres")]
        public string NombreVulgar { get; set; }

        public string Descripcion { get; set; }
        //public Peso rangoPeso { get; set; }
        //public Longitud rangoLongitud { get; set; }

        [Key, ForeignKey(nameof(EstadoConservacion))] public int IdEstadoConservacion { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }

        public List<Amenaza> _amenazas { get; set; }

        public List<EcosistemaMarino> _ecosistemas { get; set; }

        [DisplayName("Imagen")]
        public string ImgEspecie {get; set;}

      

        public EspecieMarina()
        {

        }
   

        

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if(string.IsNullOrEmpty(NombreCientifico))
            {
                throw new SpeciesException("El nombre cientifico es requerido");
            }
            if(string.IsNullOrEmpty(NombreVulgar)) 
            {
                throw new SpeciesException("El nombre vulgar es requerido");
            }
            if(NombreCientifico.Length < configuracion.GetTopeInferior("Nombre"))
            {
                throw new SpeciesException("Nombre cientifico demasiado corto");
            }
            if (NombreCientifico.Length > configuracion.GetTopeSuperior("Nombre"))
            {
                throw new SpeciesException("Nombre cientifico demasiado largo");
            }
            if (NombreVulgar.Length < configuracion.GetTopeInferior("Nombre"))
            {
                throw new SpeciesException("Nombre vulgar demasiado corto");
            }
            if (NombreVulgar.Length > configuracion.GetTopeSuperior("Nombre"))
            {
                throw new SpeciesException("Nombre vulgar demasiado largo");
            }
            if (Descripcion.Length < configuracion.GetTopeInferior("Descripcion"))
            {
                throw new Exception("Descripcion demasiado corta");
            }
            if (Descripcion.Length > configuracion.GetTopeSuperior("Descripcion"))
            {
                throw new Exception("Descripcion demasiado larga");
            }

        }
    }
}
