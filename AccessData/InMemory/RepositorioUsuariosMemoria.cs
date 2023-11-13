using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.InMemory
{
    public class RepositorioUsuariosMemoria
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        public void Add(Usuario u)
        {
            _usuarios.Add(u);
        }

        public void AddJuego(Usuario unUsuario)
        {
            _usuarios.Add(unUsuario);
        }

        public void Delete(Usuario t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorAlias(string alias)
        {
            return _usuarios.FirstOrDefault();
        }

        public void Remove(Usuario t)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
