using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Teoriemne
    {
        public int nummerIRækkefølge;
        public string emne;
        public List<KøretimeType> påkrævedeKøretimer;
        public string kørekortType;

        public Teoriemne(int nummerIRækkefølge, string emne, List<KøretimeType> påkrævedeKøretimer, string kørekortType)
        {
            this.nummerIRækkefølge = nummerIRækkefølge;
            this.emne = emne;
            this.påkrævedeKøretimer = påkrævedeKøretimer;
            this.kørekortType = kørekortType;
        }

        public override string ToString()
        {
            string køretimer = "";
            
            foreach(KøretimeType type in påkrævedeKøretimer)
            {
                køretimer += type.navn + " ";
            }
            return emne + " " + nummerIRækkefølge + " " + køretimer;
        }

    }
}