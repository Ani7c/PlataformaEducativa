using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioControlDeCambios : IRepositorioControlDeCambios
    {
        public EcosistemaMarinoContext _context;
        private IRepositorioConfiguracion config;

        public RepositorioControlDeCambios(IRepositorioConfiguracion repositorioConfiguracion)
        {
            config = repositorioConfiguracion;
            _context = new EcosistemaMarinoContext();
        }
        public void Add(ControlDeCambios t)
        {
            try
            {

                t.EsValido(config);
                _context.ControlDeCambios.Add(t);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw new Exception(@"Error al registrar los cambios");
            }
        }

        public void Delete(ControlDeCambios t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ControlDeCambios> FindAll()
        {
            throw new NotImplementedException();
        }

        public ControlDeCambios FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ControlDeCambios t)
        {
            throw new NotImplementedException();
        }
    }
}
