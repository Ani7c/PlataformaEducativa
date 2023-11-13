using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.UseCase
{
    public class LoginUC :ILogin
    {
        private IRepositorioUsuario repositorioUsuario;
 

        public LoginUC(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }


        public bool IniciarSesion(string alias, string contraseña)
        {           
            Usuario u = repositorioUsuario.ObtenerPorAlias(alias);
            
            if (u != null)
            {
                //decidimos comparar con la encriptada
                if (BCrypt.Net.BCrypt.Verify(contraseña, u.Encriptada)) 
                {
                    return true;
                }
                else return false;
            }
            else return false;
           
        }

 
    }
}
