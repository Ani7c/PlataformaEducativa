using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecosistemas_Marinos.Entidades
{
   // [Index(nameof(Alias), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    public class Usuario : IValidable
    {
      
        public int Id;
        [MinLength(8)]


        public string Contrasenia { get; set; }
        
        [MinLength(6)]
        public string Alias { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsAdmin { get; set; }

        public Usuario() 
        {
            FechaAlta = DateTime.Now;
            EsAdmin = false;
        }

        public Usuario(string contrasenia, string alias)
        {
            Contrasenia = contrasenia;
            Alias = alias;
    
            //EsAdmin = esAdmin;
        }

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if(Contrasenia.ToUpper() ==Contrasenia) 
            {
                throw new UserException("La contraseñadebe contener al menos uno de los" +
                    " siguientes caracteres: . , # ; : !");
            }
            if (Contrasenia.ToLower()== Contrasenia)
            {
                throw new UserException("La contraseñadebe contener al menos uno de los" +
                    " siguientes caracteres: . , # ; : !");
            }
            
        }
    }
}
