using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Køretime
    {
        public Køretime()
        {

        }
        public Køretime(DateTime tidStart, DateTime tidSlut)
        {
            this.tidStart = tidStart;
            this.tidSlut = tidSlut;
        }
        DateTime tidStart;
        DateTime tidSlut;

        public Elev elev; 
    }
}
