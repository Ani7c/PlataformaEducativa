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
    public class UpdateEcosystemUC : IUpdateEcosystem
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public UpdateEcosystemUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }
        public void UpdateEcosystem(EcosistemaMarino ecosystem)
        {
            this.repositorioEcosistema.Update(ecosystem);
        }
    }
}
