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
    public class GetEcosystemByIdUC : IGetEcosystemById
    {
        private IRepositorioEcosistema repositorioEcosistema;

        public GetEcosystemByIdUC(IRepositorioEcosistema repositorioEcosistema)
        {
            this.repositorioEcosistema = repositorioEcosistema;
        }

        public EcosistemaMarino GetEcosystemById(int id)
        {
            EcosistemaMarino ecosistemaMarino = repositorioEcosistema.FindById(id);
            EcosistemaDTO ecosistemaDTO = new EcosistemaDTO();
            ecosistemaDTO.IdEcosistema = ecosistemaMarino.IdEcosistema;
            ecosistemaDTO.ImgEcosistema = ecosistemaMarino.ImgEcosistema;
            ecosistemaDTO.Area = ecosistemaMarino.Area;
            ecosistemaDTO.UbicacionGeografica = ecosistemaMarino.UbicacionGeografica;
            ecosistemaDTO.Caracteristicas = ecosistemaMarino.Caracteristicas;
            ecosistemaDTO.EstadoConservacion = ecosistemaMarino.EstadoConservacion;
            ecosistemaDTO.Nombre = ecosistemaMarino.Nombre;
            ecosistemaDTO.Pais = ecosistemaMarino.Pais;
            ecosistemaDTO._amenazas = ecosistemaMarino._amenazas;
            ecosistemaDTO._especies = ecosistemaMarino._especies;

            return ecosistemaDTO;
        }
    }
}
