using Ecosistemas_Marinos.Entidades;
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
    public class RepositorioPaisesMemoria : IRepositorioPais
    {
        private static List<Pais> _paises = new List<Pais>();
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
            return _paises;
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

        public Pais BuscarPorCodigo(string codigoAlfa)
        {
            return _paises.FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
