
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dagligdagen
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            InitializeWindows();
        }
        public static Application WinApp { get; private set; }
        public static Window MainWindow { get; private set; }
        static void InitializeWindows()
        {
            WinApp = new Application();
            WinApp.Run(MainWindow = new MainWindowWpf()); // note: blocking call
        }
    }

}
