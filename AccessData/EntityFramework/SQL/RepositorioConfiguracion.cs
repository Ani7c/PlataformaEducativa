using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccessData.EntityFramework.SQL
{
    internal class RepositorioConfiguracion : IRepositorioConfiguracion
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
            throw new NotImplementedException();
        }

        public Configuracion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Configuracion t)
        {
            throw new NotImplementedException();
        }
    }
}
