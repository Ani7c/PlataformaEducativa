using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.UseCase
{
    public class FiltrarDadaUnaEspecieUC : IFiltrarDadaUnaEspecie
    {
        private IRepositorioEspecie repositorioEspecie;

        public FiltrarDadaUnaEspecieUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }

        public List<EcosistemaDTO> FiltrarDadaUnaEspecie(int IdEspecie)
        {
            List<EcosistemaMarino> ecosistemas = repositorioEspecie.FiltrarDadaUnaEspecie(IdEspecie);
            List<EcosistemaDTO> ret = new List<EcosistemaDTO>();

            foreach(EcosistemaMarino em in  ecosistemas)
            {
                EcosistemaDTO nuevo = new EcosistemaDTO(em);
                ret.Add(nuevo);
            }

            return ret;
        }
    }
}
