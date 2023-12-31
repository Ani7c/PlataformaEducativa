﻿using Ecosistemas_Marinos.Entidades;
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
    public class GuardarPaisesUC: IGuardarPaises
    {
        private IRepositorioPais repositorioPais;
        public GuardarPaisesUC(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
        }
        public void GuardarPaises(List<PaisModel> paises)
        {
            List<Pais> aGuardar = new List<Pais>();
            foreach(PaisModel p in paises)
            {
                Pais nuevo = new Pais();
                nuevo.Nombre = p.name.common;
                nuevo.Codigo = p.cca3;
                aGuardar.Add(nuevo);
            }

            repositorioPais.GuardarPaises(aGuardar);
        }
    }
}
