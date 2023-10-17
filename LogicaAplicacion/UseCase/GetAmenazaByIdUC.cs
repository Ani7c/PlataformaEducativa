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
    public class GetAmenazaByIdUC : IGetAmenazaById
    {
        private IRepositorioAmenaza repositorioAmenaza;

        public GetAmenazaByIdUC(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repositorioAmenaza = repositorioAmenaza;
        }
        public Amenaza FindById(int id)
        {
            return repositorioAmenaza.FindById(id);
        }
    }
}
