using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Entidades
{
    public class ControlDeCambios : IValidable
    {
        [Key]
        public int IdCambios { get; set; }
        public string NombreUsuario { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }
        public DateTime FechaHora { get; set; }

        public ControlDeCambios()
        {
            this.FechaHora = DateTime.Now;
        }

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if (string.IsNullOrEmpty(this.NombreUsuario))
            {
                throw new Exception("No se pueden registrar los cambios");
            }
        }
    }
}
