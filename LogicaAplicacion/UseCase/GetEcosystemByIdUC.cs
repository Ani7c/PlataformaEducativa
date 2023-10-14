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
    public class GetEcosystemByIdUC : IGetEcosystemById
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public GetEcosystemByIdUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }

        public EcosistemaMarino GetEcosystemById(int id)
        {
            return repositorioEcosistema.FindById(id);
        }
    }
}
