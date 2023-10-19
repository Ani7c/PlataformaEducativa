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
               
                if (BCrypt.Net.BCrypt.Verify(contraseña, u.Contrasenia))
                {
                    return true;
                }
                else return false;
            }
            else return false;
           
        }
 // Verificar las credenciales del usuario en la base de datos
            //turn _dbContext.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
        //ver si el usuario existe, si existe entonces valida que la contrasenia este correcta
        //si lo es, entonces devuelvo true
    

        //public bool Login(string username, string password)
        //{
        //    return false;
        //}
 
    }
}
