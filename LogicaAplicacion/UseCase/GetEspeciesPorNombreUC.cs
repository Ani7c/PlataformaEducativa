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
    public class GetEspeciesPorNombreUC : IGetEspeciesPorNombre
    {
        private IRepositorioEspecie repositorioEspecie;

        public GetEspeciesPorNombreUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }

        public List<EspecieMarina> GetEspeciesPorNombre(string nombreCientifico)
        {
            return repositorioEspecie.GetEspeciesPorNombre(nombreCientifico);
        }
    }
}
