using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class ControlDeCambiosDTO
    {
        public int IdCambios { get; set; }
        public string NombreUsuario { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }
        public DateTime FechaHora { get; set; }

        public ControlDeCambiosDTO()
        {
            this.FechaHora = DateTime.Now;
        }

        public ControlDeCambiosDTO(ControlDeCambios control)
        {
            IdCambios = control.IdCambios;
            NombreUsuario = control.NombreUsuario;
            IdEntidad = control.IdEntidad;
            TipoEntidad = control.TipoEntidad;
            FechaHora = control.FechaHora;
        }
    }
}
