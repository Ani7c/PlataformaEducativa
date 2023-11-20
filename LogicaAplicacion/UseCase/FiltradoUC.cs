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
    public class FiltradoUC : IFiltrado
    {
        private IRepositorioEspecie repositorioEspecie;

        public FiltradoUC(IRepositorioEspecie repositorioEspecie)
        {
            this.repositorioEspecie = repositorioEspecie;
        }
        public List<EspecieDTO> GetSpeciesBy(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {
            //TODO
            List<EspecieMarina> especies = repositorioEspecie.GetSpeciesBy(NombreCientifico, enPeligroExtincion, pesoMinimo, pesoMaximo, IdEcosistema);
            List<EspecieDTO> especiesDTOs = new List<EspecieDTO>();
            foreach(EspecieMarina esp in  especies) 
            {
                EspecieDTO nueva = new EspecieDTO(esp);   
                especiesDTOs.Add(nueva);
            }

            return especiesDTOs;
        }
    }
}
