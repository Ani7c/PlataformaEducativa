using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.DTOs;
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
        ConfiguracionDTO IFindSettingsByName.FindSettingsByName(string name)
        {
            Configuracion config = repositorioConfiguracion.FindByName(name);
            ConfiguracionDTO configDTO = new ConfiguracionDTO(config);

            return configDTO;
        }
    }

}
