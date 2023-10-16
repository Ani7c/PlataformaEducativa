using Ecosistemas_Marinos.Entidades;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceUseCase
{
    public interface IGetEspeciesPorNombre
    {
        public List<EspecieMarina> GetEspeciesPorNombre(string nombreCientifico);
    }
}
