using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioEstadoConservacion : IRepositorioEstadoConservacion
    {

        public EcosistemaMarinoContext _context;
        public RepositorioEstadoConservacion()
        {
            _context = new EcosistemaMarinoContext();
        }
        public void Add(EstadoConservacion t)
        {
            throw new NotImplementedException();
        }

        public void Delete(EstadoConservacion t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoConservacion> FindAll()
        {
            return _context.EstadosDeConservacion.ToList();
        }

        public EstadoConservacion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoConservacion t)
        {
            throw new NotImplementedException();
        }
    }
}
