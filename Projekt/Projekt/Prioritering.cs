using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Prioritering
    {
        public Prioritering(Køretime køretime, Elev elev, int prioritering)
        {
            this.elev = elev;
            this.køretime = køretime;
            this.prioritering = prioritering;
        }
        private Elev elev;
        private Køretime køretime;

        public int prioritering;
    }
}
