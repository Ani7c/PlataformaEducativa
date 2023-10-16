using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.InterfaceUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.UseCase
{
    public class RemoveByIdUC : IRemoveById
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public RemoveByIdUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }
        public void RemoveById(int id)
        {
            repositorioEcosistema.Remove(id);
        }
    }
}
