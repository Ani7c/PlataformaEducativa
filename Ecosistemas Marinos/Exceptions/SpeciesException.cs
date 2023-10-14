using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Exceptions
{
    public class SpeciesException:Exception
    {
        public SpeciesException() { }
        public SpeciesException(string message) : base(message) { }
        public SpeciesException(string message,  Exception ex) : base(message, ex) { }
    }
}
