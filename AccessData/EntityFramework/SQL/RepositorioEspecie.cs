using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioEspecie : IRepositorioEspecie
    {

        private EcosistemaMarinoContext _context;
        public RepositorioEspecie()
        {
            _context = new EcosistemaMarinoContext ();
        }

        
        void IRepositorio<EspecieMarina>.Add(EspecieMarina especieMarina) 
        {
            try
            {
                especieMarina.EsValido();
                _context.Especies.Add(especieMarina);
                _context.SaveChanges();
            }
            catch (SpeciesException speciesException)
            {
                throw speciesException;
            }
            catch (Exception ex)
            {
                throw new Exception(@"Error al agregar la especie marina" + ex);
            }
            //eliminar exe antes de entregar
            //TODO
        }

        public void Delete(EspecieMarina t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EspecieMarina> FindAll()
        {
            throw new NotImplementedException();
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
