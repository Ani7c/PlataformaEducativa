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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioEspecie : IRepositorioEspecie
    {

        private EcosistemaMarinoContext _context;
        private IRepositorioConfiguracion config;
        public RepositorioEspecie(IRepositorioConfiguracion repositorioConfiguracion)
        {
            config = repositorioConfiguracion;
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
                especieMarina.EsValido(config);
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

        ///REVISAR, CREO QUE NO ES NECESARIO QUE LE PASEMOS LA ESPECIE POR PARAMETRO
        public void AsociarEspecieAEcosistema(int ecosistemaId, int especieId)
        {
            var ecosistema = _context.Ecosistemas.Find(ecosistemaId);
            var especie = _context.Especies.Find(especieId);

            if (ecosistema != null && especie != null)
            {
                _context.Entry(especie).State = EntityState.Unchanged;

                ecosistema._especies.Add(especie);

                _context.SaveChanges();
            }
        }

        public IEnumerable<EspecieMarina> GetEspeciesPorNombre(string nombreCientifico)
        {
            List<EspecieMarina> ret = new List<EspecieMarina>();
            return _context.Especies.Where(especie => especie.NombreCientifico.Equals(nombreCientifico));            
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
            return _context.Especies.Where(especie => especie.Id.Equals(id)).FirstOrDefault();
       
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

        List<EspecieMarina> IRepositorioEspecie.GetEspeciesPorNombre(string nombreCientifico)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EcosistemaMarino> GetPosiblesEcosistemas()
        {
            var ecosistemasDeEspecies = _context.Especies.SelectMany(especie => especie._ecosistemas);
            return ecosistemasDeEspecies.ToList();
        }

        public List<EspecieMarina> GetSpeciesBy(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {
            List<EspecieMarina> ret = _context.Especies.ToList();

            if(!string.IsNullOrEmpty(NombreCientifico))
            {               
                ret = _context.Especies.Where(especie => especie.NombreCientifico.Equals(NombreCientifico)).ToList();
            }
            //if (enPeligroExtincion)
            //{
            //    ret = ret.Where(e =>
            //        e.EstadoConservacion < 60 ||
            //        e.Amenazas.Count > 3 ||
            //        e.Ecosistemas.Any(ec => ec.GradoConservacion < 60 && ec.Amenazas.Count > 3)
            //    );
            //}

            //if (pesoMinimo > 0)
            //{
            //    ret = ret.Where(e => e.rangoPeso.PesoMin <= pesoMinimo && e=> enPeligroExtincion.rangoPeso.PesoMax >= pesoMaximo);
            //}
            
            //if (IdEcosistema > 0)
            //{
            //    ret = ret.Where(e => e._ecosistemas.Any(ec => ec.IdEcosistema == IdEcosistema));
            //}

            return ret;
        }
    }
    

}
