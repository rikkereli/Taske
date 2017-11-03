using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    static class Køreskole
    {

        public static List<string> kørekortTyper = new List<string>()
            {
                "Bil",
                "Lastbil"
            };

        public static List<Teoriemne> teoriEmner = new List<Teoriemne>()
            {
            new Teoriemne(1, "Første", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], false, "Kravlegård"), new KøretimeType(kørekortTyper[0], false, "Vej") }, "Bil"),
            new Teoriemne(2, "Anden", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], false, "Glatbane")}, "Bil"),
            new Teoriemne(3, "Nat", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], true, "Motorvej") }, "Bil"),
            new Teoriemne(4, "Fjerde", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], false, "Nat") }, "Bil")
            };

        public static KørekorttypeKriterier bilKriterier = new KørekorttypeKriterier("Bil");

        public static void GenererKøreskole()
        {
            foreach (Teoriemne emne in teoriEmner)
            {
                bilKriterier.PåkrævedeTeoriemner.Add(emne);
            }

        }

        public static Kursusplan kursusplan = new Kursusplan(kørekortTyper[0], bilKriterier);

        public static Kursus kursus = new Kursus(kursusplan, "Bilkørekort");

        public static List<Elev> elever = new List<Elev>
            {
                new Elev("Rikke", 2, 30, new Kørebog(kursus)),
                new Elev("Lars", 3, 0, new Kørebog(kursus)),
                new Elev("Helle", 3, 10, new Kørebog(kursus)),
                new Elev("Knud", 1, 30, new Kørebog(kursus)),
                new Elev("Frederik", 2, 40, new Kørebog(kursus)),
                new Elev("Mikkel", 3, 0, new Kørebog(kursus)),
                new Elev("Casper", 0, 10, new Kørebog(kursus)),
                new Elev("Mark", 3, 10, new Kørebog(kursus)),
                new Elev("Rasmus", 4, 20, new Kørebog(kursus)),
                new Elev("Erik", 2, 10, new Kørebog(kursus))
            };

    /*
    public List<Elev> elever = new List<Elev>();
    public List<String> kørekortTyper = new List<string>();
    public List<Kursus> kurser = new List<Kursus>();
    public List<Køretime> køretimer = new List<Køretime>();
    public List<Teoriemne> teoriEmner = new List<Teoriemne>();

    public Køreskole()
    {
        kørekortTyper.Add("Bil");
        #region Opret kursus

        List<Teoriemne> teoriEmnerne = new List<Teoriemne>()
        {
        new Teoriemne(1, "Første", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], false, "Kravlegård"), new KøretimeType(kørekortTyper[0], false, "Vej") }, "Bil"),
        new Teoriemne(2, "Anden", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], false, "Glatbane")}, "Bil"),
        new Teoriemne(3, "Nat", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], true, "Motorvej") }, "Bil"),
        new Teoriemne(4, "Fjerde", new List<KøretimeType>() { new KøretimeType(kørekortTyper[0], false, "Nat") }, "Bil")
        };
        teoriEmner = teoriEmnerne;

        Kursusplan kursusplan = new Kursusplan(teoriEmner, "Standard bil");
        Kursus kursus = new Kursus(kursusplan, "Første kursus");
        #endregion

        elever.Add(new Elev("Rikke", 2, 30, new Kørebog(kursus)));
        elever.Add(new Elev("Lars", 3, 0, new Kørebog(kursus)));
        elever.Add(new Elev("Helle", 3, 10, new Kørebog(kursus)));
        elever.Add(new Elev("Knud", 1, 30, new Kørebog(kursus)));
        elever.Add(new Elev("Frederik", 2, 40, new Kørebog(kursus)));
        elever.Add(new Elev("Mikkel", 3, 0, new Kørebog(kursus)));
        elever.Add(new Elev("Casper", 0, 10, new Kørebog(kursus)));
        elever.Add(new Elev("Mark", 3, 10, new Kørebog(kursus)));
        elever.Add(new Elev("Rasmus", 4, 20, new Kørebog(kursus)));
        elever.Add(new Elev("Erik", 2, 10, new Kørebog(kursus)));

        for (int i = 0; i < 23; i++)
        {
            køretimer.Add(new Køretime());
        }
    }
    */
}
}
