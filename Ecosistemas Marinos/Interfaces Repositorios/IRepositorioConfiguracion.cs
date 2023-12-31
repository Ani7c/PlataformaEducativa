﻿using Ecosistemas_Marinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces_Repositorios
{
    public interface IRepositorioConfiguracion : IRepositorio<Configuracion>
    {
        public int GetTopeSuperior(string nombreAtributo);
        public int GetTopeInferior(string nombreAtributo);

        public Configuracion FindByName(string name);
    }
}
