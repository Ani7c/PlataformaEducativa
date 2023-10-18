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
    public class GetSettingsUC : IGetSettings
    {
        private IRepositorioConfiguracion repositorioConfiguracion;

        public GetSettingsUC(IRepositorioConfiguracion repositorioConfiguracion)
        {
            this.repositorioConfiguracion = repositorioConfiguracion;
        }
        public IEnumerable<Configuracion> GetSettings()
        {
            return repositorioConfiguracion.FindAll();
        }
    }
}
