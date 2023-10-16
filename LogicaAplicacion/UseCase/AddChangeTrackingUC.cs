using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.InterfaceUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.UseCase
{
    public class AddChangeTrackingUC : IAddChangeTracking
    {
        private IRepositorioControlDeCambios repoControlDeCambios;

        public AddChangeTrackingUC(IRepositorioControlDeCambios repoControlDeCambios)
        {
            this.repoControlDeCambios = repoControlDeCambios;
        }
        public void AddChangeTracking(ControlDeCambios cambios)
        {
            repoControlDeCambios.Add(cambios);
        }
    }
}
