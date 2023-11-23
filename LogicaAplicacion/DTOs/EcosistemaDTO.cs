using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.ValueObjects;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class EcosistemaDTO
    {
        public int IdEcosistema;
        public string Nombre { get; set; }
        public UbicacionGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public string Caracteristicas { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public Pais Pais { get; set; }

        public string ImgEcosistema { get; set; }
        public List<Amenaza> _amenazas { get; set; }
        public List<EspecieMarina>? _especies { get; set; }

        public EcosistemaDTO() 
        { 
            _amenazas = new List<Amenaza>();
            _especies = new List<EspecieMarina> { };
        }

        public EcosistemaDTO(EcosistemaMarino ecosistema)
        {
            IdEcosistema = ecosistema.IdEcosistema;
            Nombre = ecosistema.Nombre;
            UbicacionGeografica = ecosistema.UbicacionGeografica;
            Area = ecosistema.Area;
            Caracteristicas = ecosistema.Caracteristicas;
            EstadoConservacion = ecosistema.EstadoConservacion;
            Pais = ecosistema.Pais;
        }

        public string Tipo()
        {
            return "Ecosistema Marino";
        }
    }
}
