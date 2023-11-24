using Ecosistemas_Marinos.ValueObjects;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class EspecieDTO
    {
        public int Id { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public Peso rangoPeso { get; set; }
        public Longitud rangoLongitud { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public string ImgEspecie { get; set; }
        public List<Amenaza> _amenazas { get; set; }

        public List<EcosistemaMarino> _ecosistemas { get; set; }

        public EspecieDTO() 
        {
            _amenazas = new List<Amenaza> { };
            _ecosistemas = new List<EcosistemaMarino> { };
        }

        public EspecieDTO(EspecieMarina especie) 
        {

            Id = especie.Id;
            NombreCientifico = especie.NombreCientifico;
            NombreVulgar = especie.NombreVulgar;
            Descripcion = especie.Descripcion;
            rangoPeso = especie.rangoPeso;
            rangoLongitud = especie.rangoLongitud;
        }
    }
}
