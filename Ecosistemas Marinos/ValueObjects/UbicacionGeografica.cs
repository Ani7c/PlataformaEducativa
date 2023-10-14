using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.ValueObjects
{
    [Owned]
    public class UbicacionGeografica
    {
        public double Latitud { get; set; }
        public double Longitud { get; set;}

        public UbicacionGeografica() { }
        public UbicacionGeografica(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
