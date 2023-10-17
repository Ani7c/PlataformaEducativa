using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceUseCase
{
    public interface IFiltrado
    {
        public List<EspecieMarina> GetSpeciesBy(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema);
    }
}
