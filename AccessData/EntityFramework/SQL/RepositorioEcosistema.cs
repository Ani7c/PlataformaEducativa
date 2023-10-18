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
    public class RepositorioEcosistema : IRepositorioEcosistema
    {
        private EcosistemaMarinoContext _context;
        private IRepositorioConfiguracion config;
        public RepositorioEcosistema(IRepositorioConfiguracion repositorioConfiguracion)
        {
            config = repositorioConfiguracion;
            _context = new EcosistemaMarinoContext();
        }


        public void Add(EcosistemaMarino e)
        {
            try
            {            
                _context.Entry(e.Pais).State = EntityState.Unchanged;
                foreach (Amenaza a in e._amenazas)
                {
                    _context.Entry(a).State = EntityState.Unchanged;
                }

                e.EsValido(config);
                _context.Ecosistemas.Add(e);
                _context.SaveChanges();

            }
            catch (EcosystemException ecosystemException)
            {
                throw ecosystemException;
            }
            catch (Exception exe)
            {
                throw new Exception(@"Error al agregar el ecosistema marino" + exe);
            }       
        }

                 

        public void Delete(EcosistemaMarino t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EcosistemaMarino> FindAll()
        {
            return _context.Ecosistemas;
         
        }

        public EcosistemaMarino FindById(int id)
        {
            return _context.Ecosistemas.Where(e => e.IdEcosistema.Equals(id)).FirstOrDefault();
        }

        public void Remove(EcosistemaMarino t)
        {
            throw new NotImplementedException();
        }

        public void Update(EcosistemaMarino e)
        {
            try
            {
                e.EsValido(config);
                this._context.Ecosistemas.Update(e);
                this._context.SaveChanges();
            }
            catch (EcosystemException ecosystemException)
            {
                throw ecosystemException;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el ecosistema " + e.Nombre);
            }
        }

        void IRepositorio<EcosistemaMarino>.Remove(int id)
        {
            try
            {
                EcosistemaMarino em = new EcosistemaMarino();
                em.IdEcosistema = id;
                this._context.Ecosistemas.Remove(em);
                this._context.SaveChanges();
            }
            catch
            {
                throw new Exception("No se puede eliminar el ecosistema ya que tine especies que lo habitan");
            }
        }

       
    }
}
