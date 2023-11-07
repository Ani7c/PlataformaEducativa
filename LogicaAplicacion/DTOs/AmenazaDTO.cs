using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class AmenazaDTO
    {
        public int IdAmenaza;
        public string Descripcion { get; set; }

        public int Peligrosidad { get; set; }

        public AmenazaDTO(Amenaza amenaza) 
        {
            IdAmenaza = amenaza.IdAmenaza;
            Descripcion = amenaza.Descripcion;
            Peligrosidad = amenaza.Peligrosidad;
        }
    }
}
