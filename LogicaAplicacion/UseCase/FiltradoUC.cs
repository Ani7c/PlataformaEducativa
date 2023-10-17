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
    public class FiltradoUC : IFiltrado
    {
        private IRepositorioEspecie repositorioEspecie;

        public FiltradoUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }
        public List<EspecieMarina> GetSpeciesBy(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {
            return repositorioEspecie.GetSpeciesBy(NombreCientifico, enPeligroExtincion, pesoMinimo, pesoMaximo, IdEcosistema);
        }
    }
}
