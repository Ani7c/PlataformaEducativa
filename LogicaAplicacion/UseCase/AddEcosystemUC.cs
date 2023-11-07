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
    public class AddEcosystemUC: IAddEcosystem
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public AddEcosystemUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }


        public void AddEcosystem(EcosistemaDTO unEcosistema)
        {
            EcosistemaMarino aCrear = new EcosistemaMarino();
            aCrear.IdEcosistema = unEcosistema.IdEcosistema;
            aCrear.Nombre = unEcosistema.Nombre;
            aCrear.Pais = unEcosistema.Pais;
            aCrear.ImgEcosistema = unEcosistema.ImgEcosistema;

            repositorioEcosistema.Add(aCrear);
        }
    }
}
