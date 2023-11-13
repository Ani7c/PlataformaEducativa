using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceUseCase
{
    public interface IObtenerUsuario
    {
        public UsuarioDTO ObtenerUsuario(string alias, string password);
    }
}
