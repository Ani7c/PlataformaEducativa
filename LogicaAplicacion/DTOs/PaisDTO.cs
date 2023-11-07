using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class PaisDTO
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public PaisDTO(Pais pais)
        {
            Nombre = pais.Nombre;
            Codigo = pais.Codigo;
        }
    }
}
