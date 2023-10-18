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
    public class GetEstadosConservacionUC : IGetEstadosConservacion
    {
        private IRepositorioEstadoConservacion repositorioEstadoConservacion;

        public GetEstadosConservacionUC(IRepositorioEstadoConservacion repositorioEstadoConservacion)
        {
            this.repositorioEstadoConservacion = repositorioEstadoConservacion;
        }
        public IEnumerable<EstadoConservacion> GetEstadosConservacion()
        {
            return repositorioEstadoConservacion.FindAll().ToList();
        }
    }
}
