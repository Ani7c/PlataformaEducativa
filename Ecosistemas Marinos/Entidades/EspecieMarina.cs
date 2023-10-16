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

        //public List<Amenaza> _amenazas { get; set; }
 
        public List<EcosistemaMarino> _ecosistemas { get; set; }

      //  public List<EcosistemaMarino> _PosiblesEcosistemas { get; set; }

        public EspecieMarina()
        {

        }
   

        

        public void EsValido()
        {
            if(string.IsNullOrEmpty(NombreCientifico))
            {
                throw new SpeciesException("El nombre cientifico es requerido");
            }
            if(string.IsNullOrEmpty(NombreVulgar)) 
            {
                throw new SpeciesException("El nombre vulgar es requerido");
            }
            if(NombreCientifico.Length < 2 || NombreCientifico.Length>50)
            {
                throw new SpeciesException("Debe contener entre 2 y 50 caracteres");
            }
            if (NombreVulgar.Length < 2 || NombreVulgar.Length > 50)
            {
                throw new SpeciesException("Debe contener entre 2 y 50 caracteres");
            }
        }
    }
}
