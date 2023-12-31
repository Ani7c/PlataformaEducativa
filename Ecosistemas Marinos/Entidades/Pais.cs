﻿using Ecosistemas_Marinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;

namespace Ecosistemas_Marinos.Entidades
{
    [PrimaryKey(nameof(Codigo))]

    public class Pais : IValidable
    {

        [DisplayName("Nombre del pais") ]
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

        public void EsValido(IRepositorioConfiguracion configuracion)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre no valido");
            }
            if (string.IsNullOrEmpty(Codigo))
            {
                throw new Exception("Codigo no valido");
            }
            if (Nombre.Length < configuracion.GetTopeInferior("Nombre"))
            {
                throw new Exception("Nombre demasiado corto");
            }
            if (Nombre.Length > configuracion.GetTopeSuperior("Nombre"))
            {
                throw new Exception("Nombre demasiado largo");
            }
        }
    }
}
