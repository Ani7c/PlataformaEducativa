using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.InMemory
{
    public class RepositorioEcosistemasMemoria : IRepositorioEcosistema
    {
        private static List<EcosistemaMarino> _ecosistemas = new List<EcosistemaMarino>();
        public void Add(EcosistemaMarino em)
        {
            _ecosistemas.Add(em);
        }

        public void Delete(EcosistemaMarino t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EcosistemaMarino> FindAll()
        {
            return _ecosistemas;
        }

        public EcosistemaMarino FindById(int id)
        {
            return _ecosistemas.FirstOrDefault();
        }

        public void Remove(EcosistemaMarino t)
        {
            throw new NotImplementedException();
        }

        public void Update(EcosistemaMarino t)
        {
            throw new NotImplementedException();
        }
    }
}
