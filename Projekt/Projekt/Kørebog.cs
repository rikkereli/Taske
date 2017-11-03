using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Kørebog
    {
        private Elev elev;
        public KørekorttypeKriterier kørekortKriterier;
        public Kursus kursus;

        public KøretimeType manglendeKøretimetype;

        public Kørebog(Kursus kursus, Elev elev, KørekorttypeKriterier kørekorttypeKriterier)
        {
            this.kursus = kursus;
            this.kørekortKriterier = kørekorttypeKriterier;
        }
        public Kørebog(Kursus kursus)
        {
            this.kursus = kursus;
        }
    }
}
