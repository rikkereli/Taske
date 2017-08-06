using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dagligdagen
{
    class Program
    {
        static void Main(string[] args)
        {
            UserControl window = new UserControl();
            TempTestClass.TestIfProgramRuns();
            Console.ReadKey();
        }
    }
}
