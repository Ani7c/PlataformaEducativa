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
    public class GetSpeciesUC : IGetSpecies
    {
        private IRepositorioEspecie repositorioEspecie;

        public GetSpeciesUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }

        public List<EspecieDTO> GetSpecies()
        {
            List<EspecieMarina> especies = repositorioEspecie.FindAll().ToList();
            List<EspecieDTO> especiesDTO = new List<EspecieDTO>();
            foreach(EspecieMarina e in especies)
            {
                EspecieDTO nueva = new EspecieDTO(e);
                especiesDTO.Add(nueva);
            }

            return especiesDTO;
        }
    }
}
