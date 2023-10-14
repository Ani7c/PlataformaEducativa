using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EcosistemasMarinos.Entidades
{
  //  [Index(nameof(Nombre), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    public class EstadoConservacion :IValidable
    {
    
        public int Id;

      //  [Required, Column("Nombre estado conservacion"), StringLength(50, MinimumLength = 2)]
        
        public string Nombre { get; set; }

        public RangoSeguridad RangoDeSeguridad { get; set; }

        public EstadoConservacion() { }

        public EstadoConservacion(string nombre)
        {
            Nombre = nombre;
        }

        public void EsValido() { }

    }
}
