using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceUseCase
{
    public interface IFindSettingsByName
    {
        public Configuracion FindSettingsByName(string name);   
    }
}
