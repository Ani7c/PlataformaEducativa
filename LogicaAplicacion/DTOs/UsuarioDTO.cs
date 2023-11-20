using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class UsuarioDTO
    {
        public int Id;
        public string Contrasenia { get; set; }

        public string? Encriptada { get; set; }
        public string Alias { get; set; }
        public DateTime? FechaAlta { get; set; }
        public bool? EsAdmin { get; set; }

        public string? Token { get; set; }
        public UsuarioDTO()
        {
            FechaAlta = DateTime.Now;
        }

        public UsuarioDTO(Usuario usuario)
        {
            Id = usuario.Id;
            Alias = usuario.Alias;
            Contrasenia = usuario.Contrasenia; 
            //Encriptada = usuario.Encriptada;
            EsAdmin = usuario.EsAdmin;
        }
    }
}
