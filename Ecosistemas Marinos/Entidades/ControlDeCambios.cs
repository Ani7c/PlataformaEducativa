using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Entidades
{
    public class ControlDeCambios
    {
        [Key]
        public int IdCambios { get; set; }
        public string NombreUsuario { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }
        public DateTime FechaHora { get; set; }

        public ControlDeCambios()
        {
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
