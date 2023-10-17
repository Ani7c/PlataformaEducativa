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
    public class AddSpecieToEcosystemUC : IAddSpecieToEcosystem
    {
        private IRepositorioEspecie repositorioEspecie;

        public AddSpecieToEcosystemUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }

        public void AsociarEspecieAEcosistema(int especieId, int eco)
        {
            repositorioEspecie.AsociarEspecieAEcosistema(especieId, eco);

        }
    }
}
