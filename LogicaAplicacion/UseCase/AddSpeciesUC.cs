using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.UseCase
{
    public class AddSpeciesUC : IAddSpecies
    {
        private IRepositorioEspecie repositorioEspecie;

        public AddSpeciesUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }


        public void AddSpecies(EspecieDTO unaEspecie)
        {
            EspecieMarina aCrear = new EspecieMarina();
            aCrear.NombreCientifico = unaEspecie.NombreCientifico;
            aCrear.NombreVulgar = unaEspecie.NombreVulgar;
            aCrear.Id = unaEspecie.Id;
            aCrear.Descripcion = unaEspecie.Descripcion;
            aCrear.rangoPeso = unaEspecie.rangoPeso;
            aCrear.rangoLongitud = unaEspecie.rangoLongitud;
            aCrear.ImgEspecie = unaEspecie.ImgEspecie;


            repositorioEspecie.Add(aCrear);
        }
    }
}
