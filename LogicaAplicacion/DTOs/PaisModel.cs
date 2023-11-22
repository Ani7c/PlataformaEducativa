using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class PaisModel
    {
        //Nombre
        public Name name { get; set; }

        //Codigo
        public string cca3 { get; set; }

    }
    public class Name  
    { 
        public string common { get; set; }
    }

    
}
