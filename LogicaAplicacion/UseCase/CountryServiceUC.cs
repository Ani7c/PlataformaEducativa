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
    public class CountryServiceUC: ICountryService
    {
        private IRepositorioPais repositorioPais;
        public CountryServiceUC(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
        }
        public async Task SaveCountries(List<Pais> countries)
        {
            repositorioPais.SaveCountries(countries);
        }
    }
}
