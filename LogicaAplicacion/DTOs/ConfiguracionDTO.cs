using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class ConfiguracionDTO
    {
        public string NombreAtributo { get; set; }

        public int TopeSuperior { get; set; }

        public int TopeInferior { get; set; }

        public ConfiguracionDTO(Configuracion configuracion) 
        {
            NombreAtributo = configuracion.NombreAtributo;
            TopeSuperior = configuracion.TopeSuperior;
            TopeInferior = configuracion.TopeInferior;
        }

        public ConfiguracionDTO() { }

    }
}
