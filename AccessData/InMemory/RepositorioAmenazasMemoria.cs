using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.InMemory
{
    public class RepositorioAmenazasMemoria : IRepositorioAmenaza
    {
        private static List<Amenaza> _amenazas = new List<Amenaza>();

        public void Add(Amenaza t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Amenaza t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Amenaza> FindAll()
        {
            throw new NotImplementedException();
        }

        public Amenaza FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Amenaza t)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Amenaza t)
        {
            throw new NotImplementedException();
        }
    }
}
