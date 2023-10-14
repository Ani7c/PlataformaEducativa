using Ecosistemas_Marinos.Entidades;
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
    public class AddEcosystemUC: IAddEcosystem
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public AddEcosystemUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }


        public void AddEcosystem(EcosistemaMarino unEcosistema)
        {
            repositorioEcosistema.Add(unEcosistema);
        }
    }
}
