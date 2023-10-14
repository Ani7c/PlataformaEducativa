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
    public class GetSpeciesUC : IGetSpecies
    {
        private IRepositorioEspecie repositorioEspecie;

        public GetSpeciesUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }

        public List<EspecieMarina> GetSpecies()
        {
            return repositorioEspecie.FindAll().ToList();
        }
    }
}
