using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
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

        public void Update(EspecieMarina t)
        {
            throw new NotImplementedException();
        }
    }
}
