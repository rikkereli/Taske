using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// The class that communicates with the person
    /// </summary>
    class UserInterface
    {
        /// <summary>
        /// Run the system
        /// </summary>
        public void Run(DailyLifeSystem system)
        {

        }
        //The first message the user gets
        public void HelloMessage()
        {
            Console.WriteLine("Hello and welcome to the daily life tracker. Please choose an option");
        }
    }
}
