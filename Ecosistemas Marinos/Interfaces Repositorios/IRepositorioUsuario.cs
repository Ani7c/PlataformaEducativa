using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces_Repositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario ObtenerPorAlias(string alias);

        public Usuario ObtenerUsuario(string alias, string password);
    }
}
