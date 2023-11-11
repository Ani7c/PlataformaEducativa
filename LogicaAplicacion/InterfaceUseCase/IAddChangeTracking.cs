using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceUseCase
{
    public interface IAddChangeTracking
    {
        public void AddChangeTracking(ControlDeCambiosDTO cambios);
    }
}
