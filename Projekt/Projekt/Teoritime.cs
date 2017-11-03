using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Teoritime
    {
        public Teoritime(List<Teoriemne> teoriemner, Kursus kursus)
        {
            this.teoriemner = teoriemner;
            this.kursus = kursus;
        }
        Kursus kursus;
        List<Teoriemne> teoriemner;
    }
}
