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
    public class FiltrarDadaUnaEspecieUC : IFiltrarDadaUnaEspecie
    {
        private IRepositorioEspecie repositorioEspecie;

        public FiltrarDadaUnaEspecieUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }

        public List<EcosistemaMarino> FiltrarDadaUnaEspecie(int IdEspecie)
        {
            return repositorioEspecie.FiltrarDadaUnaEspecie(IdEspecie);
        }
    }
}
