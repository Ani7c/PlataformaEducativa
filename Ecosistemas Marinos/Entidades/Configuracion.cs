using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Entidades
{
    public class Configuracion :IValidable
    {
        [Key]
        public string NombreAtributo {  get; set; }

        public int TopeSuperior { get; set; }

        public int TopeInferior { get; set; }

        public Configuracion() { }

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if (TopeInferior > TopeSuperior)
            {
                throw new Exception("Topes no validos");
            }
            if(string.IsNullOrEmpty(NombreAtributo))
            {
                throw new Exception("Debe tener nombre");
            }
        }
    }
}
