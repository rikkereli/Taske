using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string s) : base (s)
        {

        }
    }
}
