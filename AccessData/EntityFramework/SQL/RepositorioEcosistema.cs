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
        public RepositorioEcosistema()
        {
            _context = new EcosistemaMarinoContext();
        }


        void IRepositorio<EcosistemaMarino>.Add(EcosistemaMarino e)
        {
            try
            {
                e.EsValido();
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

        public void Update(EcosistemaMarino t)
        {
            throw new NotImplementedException();
        }
    }
}
