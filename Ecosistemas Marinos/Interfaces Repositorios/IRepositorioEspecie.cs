﻿using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces_Repositorios
{
    public interface IRepositorioEspecie : IRepositorio<EspecieMarina>
    {
        void AsociarEspecieAEcosistema(int especieId, int ecosistemaId);

        public List<EspecieMarina> GetEspeciesPorNombre(string nombreCientifico);


        public IEnumerable<EcosistemaMarino> GetPosiblesEcosistemas();

        public List<EspecieMarina> GetSpeciesBy(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema);

        public List<EcosistemaMarino> FiltrarDadaUnaEspecie(int IdEspecie);
    }

}
