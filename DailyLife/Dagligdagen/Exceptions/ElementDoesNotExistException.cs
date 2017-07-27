using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// Is cast when an element does not exist
    /// </summary>
    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException(string s) : base (s)
        {

        }
    }
}
