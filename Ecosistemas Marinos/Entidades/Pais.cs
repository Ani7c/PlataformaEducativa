using Ecosistemas_Marinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Entidades
{
    [PrimaryKey(nameof(CodAlpha))]

    public class Pais : IValidable
    {

        public string Nombre { get; set; }
        public string Codigo { get; set; }



        public Pais(string nombre, string codigo)
        {
            Nombre = nombre;
            Codigo = codigo;
        }

        public Pais()
        {

        }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre no valido");
            }
            if (string.IsNullOrEmpty(Codigo))
            {
                throw new Exception("Codigo no valido");
            }
        }
    }
}
