using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using Microsoft.EntityFrameworkCore;
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
                foreach (EcosistemaMarino eco in especieMarina._ecosistemas)
                {
                    _context.Entry(eco).State = EntityState.Unchanged;
                }
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


        public void AsociarEspecieAEcosistema(EspecieMarina especie, EcosistemaMarino ecosistema)
        {
            /*var ecosistema = _context.Ecosistemas.Find(ecosistemaId);
            var especie = _context.Especies.Find(especieId);*/

            if (ecosistema != null && especie != null)
            {
                _context.Entry(especie).State = EntityState.Unchanged;

                ecosistema._especies.Add(especie);

                _context.SaveChanges();
            }
        }



        public void Delete(EspecieMarina t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EspecieMarina> FindAll()
        {
            return _context.Especies;
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

    }

}
