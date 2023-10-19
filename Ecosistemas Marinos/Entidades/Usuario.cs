using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecosistemas_Marinos.Entidades
{
    [Index(nameof(Alias), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    public class Usuario : IValidable
    {
      
        public int Id;
        [MinLength(8)]

        public string Contrasenia { get; set; }

        public string Encriptada { get; set; }
        
        [MinLength(6)]
        public string Alias { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsAdmin { get; set; }

        public Usuario() 
        {
            FechaAlta = DateTime.Now;
        }

       

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if(Contrasenia.ToUpper() ==Contrasenia) 
            {
                throw new UserException("La contraseña debe contener mayusculas y minusculas");
            }
            if (Contrasenia.ToLower()== Contrasenia)
            {
                throw new UserException("La contraseña debe contener mayusculas y minusculas");
            }
            //if (!ContieneCaracterEspecial(Contrasenia)){
            //    throw new UserException("La contraseña debe contener caracteres especiales");
            //}
            if (Alias.Length < 6)
            {
                throw new UserException("Alias demasiado corto");
            }
            if (Contrasenia.Length < 8)
            {
                throw new UserException("Contraseña demasiado corta");
            }
        }

        static bool ContieneCaracterEspecial(string password)
        {
            string pattern = @".,#;:!";
            Regex regex = new Regex(pattern);

            // Utilizamos el método Any para verificar si hay al menos un carácter especial
            return regex.Matches(password).Cast<Match>().Any();
        }
    }
}
