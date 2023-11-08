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
    public class AddUserUC : IAddUser
    {
        private IRepositorioUsuario repositorioUsuario;

        public AddUserUC(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }


        public void AddUser(UsuarioDTO unUsuario)
        {
            Usuario aCrear = new Usuario();
            aCrear.Id = unUsuario.Id;
            aCrear.Alias = unUsuario.Alias;
            aCrear.Contrasenia = unUsuario.Contrasenia;
            aCrear.Encriptada = unUsuario.Encriptada;

            repositorioUsuario.Add(aCrear);
        }
    }
}
