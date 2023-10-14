using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioPais : IRepositorioPais
    {
        private EcosistemaMarinoContext _context;
        public RepositorioPais()
        {
            _context = new EcosistemaMarinoContext();
        }
        public void Add(Pais t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pais t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindAll()
        {
            return _context.Paises;
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Pais t)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais t)
        {
            throw new NotImplementedException();
        }
    }
}
