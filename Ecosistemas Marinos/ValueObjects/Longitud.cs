using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.ValueObjects
{
    [Owned]
    public class Longitud :IValidable
    {
        public double LongitudMin { get; set; }
        public double LongitudMax { get; set; }
         
        public Longitud(){}

        public Longitud(double longitudMin, double longitudMax)
        {
            LongitudMin = longitudMin;
            LongitudMax = longitudMax;
        }
        
        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if(LongitudMin > LongitudMax)
            {
                throw new Exception("Longitud no valida");
            }
            if(LongitudMin < 0)
            { 
                throw new Exception("Longitud minima no valida");
            }
        }
        public double Average()
        {
            return (LongitudMin + LongitudMax)/2;
        }   
    }
}
