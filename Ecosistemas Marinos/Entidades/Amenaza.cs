using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    [PrimaryKey(nameof(IdAmenaza))]
    public class Amenaza: IValidable
    {
       
        public int IdAmenaza;
        public string Descripcion { get; set; }

        //[Range ]
        public int Peligrosidad { get; set; }

        public Amenaza(string descripcion, int peligrosidad)
        {
            Descripcion = descripcion;
            this.Peligrosidad = peligrosidad;
        }

        public Amenaza() { }

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if (Peligrosidad < 1 || Peligrosidad > 10)
            {
                throw new Exception("Debe estar entre 1 y 10");
            }
            if (Descripcion.Length < configuracion.GetTopeInferior("Descripcion"))
            {
                throw new Exception("Descripcion demasiado corta");
            }
            if(Descripcion.Length > configuracion.GetTopeSuperior("Descripcion"))
            {
                throw new Exception("Descripcion demasiado larga");
            }
        }
    }
}
