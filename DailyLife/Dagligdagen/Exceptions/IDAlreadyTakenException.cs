using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class IDAlreadyTakenException : Exception
    {
        public IDAlreadyTakenException(string s) : base (s)
        {

        }
    }
}
