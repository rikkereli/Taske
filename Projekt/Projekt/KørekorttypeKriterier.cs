using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class KørekorttypeKriterier
    {
        public KørekorttypeKriterier(string kørekortType)
        {
            this.kørekortType = kørekortType;
        }

        private List<Teoriemne> påkrævedeTeoriemner = new List<Teoriemne>();

        public List<Teoriemne> PåkrævedeTeoriemner
        {
            get { return påkrævedeTeoriemner; }
        }
        public void TilføjPåkrævetTeoriemne(Teoriemne emne)
        {
            foreach(Teoriemne påkrævetEmne in påkrævedeTeoriemner)
            {
                //Sørger for at rækkefølgen er overholdt
                if(påkrævetEmne.nummerIRækkefølge >= emne.nummerIRækkefølge) 
                {
                    påkrævetEmne.nummerIRækkefølge++;
                }
            }
            påkrævedeTeoriemner.Add(emne);
            PåkrævedeTeoriemner.Sort((x, y) => x.nummerIRækkefølge.CompareTo(y.nummerIRækkefølge));
        }

        public string kørekortType;
    }
}
