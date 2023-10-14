using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceUseCase
{
    public interface ILogin
    {
        public bool IniciarSesion(string alias, string contraseña);
    }
}
