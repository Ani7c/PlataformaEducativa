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
    public class UpdateSettingsUC : IUpdateSettings
    {
        private IRepositorioConfiguracion repositorioConfiguracion;

        public UpdateSettingsUC(IRepositorioConfiguracion repositorioConfiguracion)
        {
            this.repositorioConfiguracion = repositorioConfiguracion;
        }
        public void UpdateSettings(ConfiguracionDTO configuracion)
        {
            Configuracion toUpdate = new Configuracion();
            toUpdate.NombreAtributo = configuracion.NombreAtributo;
            toUpdate.TopeSuperior = configuracion.TopeSuperior;
            toUpdate.TopeInferior = configuracion.TopeInferior;

            repositorioConfiguracion.Update(toUpdate);
        }
    }
}
