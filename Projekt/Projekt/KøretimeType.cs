using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class KøretimeType
    {
        //Bør måske implementeres i stedet for natkørsel for at fortælle hvornår køretimen bør afholdes.
        public DateTime Tidsrum;
        //Fortæller hvad man øver her
        public string navn;
        //Se om det er natkørsel
        public bool erNat;
        //Hvilken type kørekort hører den til?
        public string kørekortType;

        public KøretimeType(string kørekortType, bool erNat, string navn)
        {
            this.kørekortType = kørekortType;
            this.erNat = erNat;
            this.navn = navn;
        }
    }
}
