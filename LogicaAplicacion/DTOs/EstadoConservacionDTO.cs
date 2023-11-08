using Ecosistemas_Marinos.Entidades;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class EstadoConservacionDTO
    {
        public int Id;

        public string Nombre { get; set; }

        public int ValorMin { get; set; }

        public int ValorMax { get; set; }
        public RangoSeguridad RangoDeSeguridad { get; set; }

        public EstadoConservacionDTO(EstadoConservacion estadoConservacion)
        {
            Id = estadoConservacion.Id;
            Nombre = estadoConservacion.Nombre;
            ValorMin = estadoConservacion.ValorMin;
            ValorMax = estadoConservacion.ValorMax;
            RangoDeSeguridad = estadoConservacion.RangoDeSeguridad;
        }

    }
}
