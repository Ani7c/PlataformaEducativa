using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioConfiguracion : IRepositorioConfiguracion
    {
        
        public EcosistemaMarinoContext _context;
        public RepositorioConfiguracion()
        {
            
            _context = new EcosistemaMarinoContext();
        }

        public int GetTopeInferior(string nombreAtributo)
        {
            Configuracion configuracion = _context.Configuraciones.Where(config => config.NombreAtributo == nombreAtributo).FirstOrDefault();
            if (configuracion == null) throw new Exception("Nombre atributo incorrecto");
            return configuracion.TopeInferior;
        }

        public int GetTopeSuperior(string nombreAtributo)
        {
            Configuracion configuracion = _context.Configuraciones.Where(config => config.NombreAtributo == nombreAtributo).FirstOrDefault();
            if (configuracion == null) throw new Exception("Nombre atributo incorrecto");
            return configuracion.TopeSuperior;
        }
        public void Add(Configuracion t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Configuracion t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> FindAll()
        {
            return _context.Configuraciones.ToList();
        }

        public Configuracion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Configuracion FindByName(string name)
        {
            return _context.Configuraciones.Where(c => c.NombreAtributo.Equals(name)).FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Configuracion c)
        {
            try
            {
          
                this._context.Configuraciones.Update(c);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar" + ex);
            }
        }
    }
}
