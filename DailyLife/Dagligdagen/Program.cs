using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    class Program
    {
        static void Main(string[] args)
        {
            string wrongYearFormat = "25/07/1721 12:30:05";

            Console.WriteLine(ReadFromFiles.StringToDateTime(wrongYearFormat));
            Console.ReadKey();
        }
    }
}
