using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Kursus
    {
        string navn;
        Kursusplan kursusplan;

        public Kursus(Kursusplan kursusplan, string navn)
        {
            this.navn = navn;
            this.kursusplan = kursusplan;
        }
        public List<Teoritime> teoritime = new List<Teoritime>();
    }
}
