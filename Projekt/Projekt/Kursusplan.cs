using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Kursusplan
    {
        public string navn;
        public List<SamledeTeori> planlagteTeorilektioner = new List<SamledeTeori>();

        public bool erKomplet = false;

        public void TilføjPlanlagteTeorilektioner(SamledeTeori samledeTeori)
        {
            bool kanTilføjes = true;
            foreach (Teoriemne emne in samledeTeori.teoriemner)
            {
                if (!(typeKørekort.kørekortType == emne.kørekortType))
                {
                    kanTilføjes = false;
                }
            }
            foreach (SamledeTeori teori in planlagteTeorilektioner)
            {
                while (kanTilføjes)
                {
                    if (teori.nummerIRækkefølge == (samledeTeori.nummerIRækkefølge))
                    {
                        if (!(teori.teoriemner.Last().nummerIRækkefølge == (samledeTeori.teoriemner.First().nummerIRækkefølge - 1)))
                        {
                            kanTilføjes = false;
                        }
                    }
                    else if (teori.nummerIRækkefølge == (samledeTeori.nummerIRækkefølge))
                    {
                        if (!(teori.teoriemner.First().nummerIRækkefølge == (samledeTeori.teoriemner.Last().nummerIRækkefølge + 1)))
                        {
                            kanTilføjes = false;
                        }
                    }
                }
            }
            if(kanTilføjes)
            {
                foreach(SamledeTeori teori in planlagteTeorilektioner)
                {
                    if(teori.nummerIRækkefølge >= samledeTeori.nummerIRækkefølge)
                    {
                        teori.nummerIRækkefølge++;
                    }
                }
                planlagteTeorilektioner.Add(samledeTeori);
                planlagteTeorilektioner.Sort((x, y) => x.nummerIRækkefølge.CompareTo(y.nummerIRækkefølge));
            }
            if(!kanTilføjes)
            {
                throw new Exception("Din time kan ikke tilføjes");
            }
        }
        /// <summary>
        /// Se om kursusplan indeholder alle de teoritimer den skal
        /// </summary>
        /// <returns></returns>
        public bool SeOmKørekorttypekriterierErOpfyldt()
        {
            bool erOpfyldt = true;
            foreach(Teoriemne emne in typeKørekort.PåkrævedeTeoriemner)
            {
                erOpfyldt = false;
                foreach(SamledeTeori teori in planlagteTeorilektioner)
                {
                    foreach (Teoriemne teoriemne in teori.teoriemner)
                    {
                        if(teoriemne == emne)
                        {
                            erOpfyldt = true;
                        }
                    }
                }
            }
            return erOpfyldt;
        }

        public KørekorttypeKriterier typeKørekort;

        public Kursusplan(string navn, KørekorttypeKriterier typeKørekort)
        {
            this.navn = navn;
            this.typeKørekort = typeKørekort;
        }
    }
}
