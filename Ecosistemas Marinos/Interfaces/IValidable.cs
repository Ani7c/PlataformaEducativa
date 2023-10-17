using Ecosistemas_Marinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces
{
    public interface IValidable
    {
        public void EsValido(IRepositorioConfiguracion configuracion);
    }
}
