using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
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


        public void AddSpecies(EspecieMarina unaEspecie)
        {
            repositorioEspecie.Add(unaEspecie);
        }
    }
}
