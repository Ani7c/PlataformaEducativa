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
    public class GetThreatsUC : IGetThreats
    {
        private IRepositorioAmenaza repositorioAmenaza;

        public GetThreatsUC(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repositorioAmenaza = repositorioAmenaza;
        }

        public List<Amenaza> GetAmenazas()
        {
            return repositorioAmenaza.FindAll().ToList();
        }

     
    }
}
