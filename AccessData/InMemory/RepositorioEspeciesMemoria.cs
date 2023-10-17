using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.InMemory
{
    public class RepositorioEspeciesMemoria : IRepositorioEspecie
    {
        private static List<EspecieMarina> _especies = new List<EspecieMarina>();
        public void Add(EspecieMarina esp)
        {
            _especies.Add(esp);
        }

        public void Delete(EspecieMarina t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EspecieMarina> FindAll()
        {
            return _especies;
        }

        public EspecieMarina FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EspecieMarina t)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EspecieMarina t)
        {
            throw new NotImplementedException();
        }

        //public void asociarespecieaecosistema(int especieid, int eco)
        //{
        //    _especies.Add(FindById(eco));
        //   // eco._especies.add(especieid);

        //}

        public List<EspecieMarina> GetEspeciesPorNombre(string nombreCientifico)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EcosistemaMarino> GetPosiblesEcosistemas()
        {
            return new List<EcosistemaMarino>();
        }

        public void AsociarEspecieAEcosistema(int especieId, int ecosistemaId)
        {
            _especies.Add(FindById(ecosistemaId));
        }

        public List<EspecieMarina> GetSpeciesBy(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {
            throw new NotImplementedException();
        }
    }
}
