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
    public class GetSpecieByIdUC : IGetSpecieById
    {
        private IRepositorioEspecie repositorioEspecie;

        public GetSpecieByIdUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }
        public EspecieMarina FindById(int id)
        {
            return repositorioEspecie.FindById(id);
        }
    }
}
