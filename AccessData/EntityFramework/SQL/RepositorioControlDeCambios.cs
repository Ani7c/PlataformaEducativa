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
        public RepositorioControlDeCambios()
        {
            _context = new EcosistemaMarinoContext();
        }
        public void Add(ControlDeCambios t)
        {
            try
            {

                //_context.Entry(e.Pais).State = EntityState.Unchanged;

                //t.EsValido();
                _context.ControlDeCambios.Add(t);
                _context.SaveChanges();

            }
            catch (Exception exe)
            {
                throw new Exception(@"Error al registrar los cambios" + exe);
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
