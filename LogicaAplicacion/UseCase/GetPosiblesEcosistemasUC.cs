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
    public class GetPosiblesEcosistemasUC : IGetPosiblesEcosistemas
    {
        private IRepositorioEspecie repositorioEspecie;

        public GetPosiblesEcosistemasUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }
        public List<EcosistemaMarino> GetPosiblesEcosistemas()
        {
            return repositorioEspecie.GetPosiblesEcosistemas().ToList();
        }
    }
}
