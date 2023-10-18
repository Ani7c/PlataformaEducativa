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
    public class FindSettingsByNameUC : IFindSettingsByName
    {
        private IRepositorioConfiguracion repositorioConfiguracion;

        public FindSettingsByNameUC(IRepositorioConfiguracion repositorioConfiguracion)
        {
            this.repositorioConfiguracion = repositorioConfiguracion;
        }
        Configuracion IFindSettingsByName.FindSettingsByName(string name)
        {
            return repositorioConfiguracion.FindByName(name);
        }
    }
}
