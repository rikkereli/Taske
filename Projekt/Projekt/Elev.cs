using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Elev
    {
        public Elev(string navn, List<Køretime> manglendeKøretimer, int konto, Kørebog kørebog)
        {
            this.navn = navn;
            this.konto = konto;
            this.manglendeKøretimer = manglendeKøretimer;
            kørebøger.Add(kørebog);
        }
        public Elev(string navn, int m, int konto, Kørebog kørebog)
        {
            this.navn = navn;
            this.konto = konto;
            kørebøger.Add(kørebog);
        }
        List<Kørebog> kørebøger = new List<Kørebog>();
        private string navn;
        public int konto;
        public List<Køretime> aktiveKøretimer;
        public List<Køretime> manglendeKøretimer; 

        public override string ToString()
        {
            string køretimer = "";
            foreach(Køretime køretime in aktiveKøretimer)
            {
                køretimer += køretime.ToString() + "\n";
            }
            return $"{navn} {konto} {manglendeKøretimer} \n {køretimer} \n";
        }
    }
}
