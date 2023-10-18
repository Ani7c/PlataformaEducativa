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
    public class UpdateSpecieUC : IUpdateSpecie
    {
        private IRepositorioEspecie repositorioEspecie;

        public UpdateSpecieUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }
        public void UpdateSpecie(EspecieMarina especieMarina)
        {
            repositorioEspecie.Update(especieMarina);
        }
    }
}
