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
    public class GetCountriesUC : IGetCountries
    {
        private IRepositorioPais repositorioPais;

        public GetCountriesUC(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
        }
        public List<Pais> GetCountries()
        {
            return repositorioPais.FindAll().ToList();
        }
       
    }
}
