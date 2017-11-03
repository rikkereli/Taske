using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    /// <summary>
    /// Sørger for at man i køreplanen kan samle teori
    /// </summary>
    class SamledeTeori : Aktivitet
    {
        public List<Teoriemne> teoriemner;
        public int nummerIRækkefølge;

        public SamledeTeori(List<Teoriemne> emner, int nummerIRækkefølge, string kørekortType)
        {
            foreach(Teoriemne emne in emner)
            {
                if (!(emne.kørekortType == kørekortType))
                {
                    throw new Exception();
                }
            }
            this.nummerIRækkefølge = nummerIRækkefølge;
            emner.Sort((x,y) => x.nummerIRækkefølge.CompareTo(y.nummerIRækkefølge));
            int sidteNummerIRækkefølge = emner.First().nummerIRækkefølge - 1; 
            foreach (Teoriemne emne in emner)
            {
                if(!(sidteNummerIRækkefølge == (emne.nummerIRækkefølge - 1)))
                {
                    throw new Exception("Rækkefølgen passer ikke");
                }
            }
            teoriemner = emner;
        }

    }
}
