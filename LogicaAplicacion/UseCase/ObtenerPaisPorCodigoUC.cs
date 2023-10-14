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
    public class ObtenerPaisPorCodigoUC : IObtenerPaisPorCodigo
    {
        private IRepositorioPais repositorioPais;
        public ObtenerPaisPorCodigoUC(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
        }
        public Pais BuscarPorCodigo(string codigoAlfa)
        {
            return repositorioPais.BuscarPorCodigo(codigoAlfa);
        }
    }
}
