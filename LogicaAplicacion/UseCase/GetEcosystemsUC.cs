﻿using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
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
        public List<EcosistemaMarino> GetEcosystems()
        {
            return repositorioEcosistema.FindAll().ToList();
        }
    }
}
