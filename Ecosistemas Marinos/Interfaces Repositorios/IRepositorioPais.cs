using Ecosistemas_Marinos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces_Repositorios
{
    public interface IRepositorioPais : IRepositorio<Pais>
    {
        public Pais BuscarPorCodigo(string codigoAlfa);

        public void GuardarPaises(List<Pais> listaPais);

    }   
}
