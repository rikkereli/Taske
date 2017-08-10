using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class MainTransaction
    {
        private uint iD;
        /// <summary>
        /// The unique head transaction ID
        /// </summary>
        public uint ID
        {
            get { return iD; }
        }

        private DateTime date;
        /// <summary>
        /// The date of the transaction
        /// </summary>
        public DateTime Date
        {
            get { return date;}
        }
        /// <summary>
        /// The list of elements in this transaction
        /// </summary>
        public ListOfTransactions listOfTransactions;
        /// <summary>
        /// a comment on the transaction
        /// </summary>
        public string comment;

        public MainTransaction()
        {

        }


    }
}
