using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Exceptions
{
    public class EcosystemException : Exception
    {
        public EcosystemException() { }
        public EcosystemException(string message) : base(message) { }
        public EcosystemException(string message, Exception ex) : base(message, ex) { }
    }
}
