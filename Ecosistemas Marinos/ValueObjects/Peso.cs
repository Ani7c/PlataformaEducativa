using Ecosistemas_Marinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.ValueObjects
{
    [Owned]
    public class Peso : IValidable
    {
        [Range(0, int.MaxValue)]
        public double PesoMin { get; set; }

        [Range(0, int.MaxValue)]
        public double PesoMax { get; set; }
        public Peso() { }
        public Peso(double min, double max)
        {
            PesoMin = min;
            PesoMax = max;
        }

        public double Average()
        {
            return (PesoMax + PesoMax) / 2;
        }

        public void EsValido()
        {
            if (PesoMin < 0)
            {
                throw new Exception("Peso minimo no valido");
            }
        }



    }
}
