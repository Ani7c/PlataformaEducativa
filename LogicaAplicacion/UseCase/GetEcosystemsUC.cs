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
    public class GetEcosystemsUC : IGetEcosystem
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public GetEcosystemsUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }
        public List<EcosistemaDTO> GetEcosystems()
        {
            List<EcosistemaMarino> ecosistemas = repositorioEcosistema.FindAll().ToList();

            List<EcosistemaDTO> ret = new List<EcosistemaDTO> ();
            foreach(EcosistemaMarino e in ecosistemas)
            {
                EcosistemaDTO nuevo = new EcosistemaDTO(e);
                ret.Add(nuevo);
            }

            return ret;
        }
    }
}
