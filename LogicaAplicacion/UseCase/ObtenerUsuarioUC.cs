using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.UseCase
{
    public class ObtenerUsuarioUC : IObtenerUsuario
    {
        private IRepositorioUsuario repositorioUsuario;


        public ObtenerUsuarioUC(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }
        public UsuarioDTO ObtenerUsuario(string alias, string password)
        {
            Usuario user = repositorioUsuario.ObtenerUsuario(alias, password);

            return new UsuarioDTO(user);
        }
    }
}
