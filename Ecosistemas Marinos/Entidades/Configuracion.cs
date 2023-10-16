using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Entidades
{
    public class Configuracion
    {
        [Key]
        public string NombreAtributo {  get; set; }

        public int TopeSuperior { get; set; }

        public int TopeInferior { get; set; }

        public Configuracion() { }


    }
}
