using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class MainBuyTransaction : MainTransaction
    {
        /// <summary>
        /// Make a transaction with an existing list of products
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="date"></param>
        /// <param name="iD"></param>
        /// <param name="transactions"></param>
        /// <param name="price"></param>
        /// <param name="place"></param>
        public MainBuyTransaction(string comment, DateTime date, int iD, ListOfTransactions transactions, decimal price, string place) : base(comment, date, iD, price)
        {
            ListOfTransactions = transactions;
            this.place = place;
        }

        public MainBuyTransaction(string comment, DateTime date, int iD, decimal price, string place, IUserinterface uI) : base(comment, date, iD, price)
        {
            this.place = place;
            ListOfTransactions = new ListOfTransactions(uI);
        }
        /// <summary>
        /// The list of elements in this transaction
        /// </summary>
        public ListOfTransactions ListOfTransactions
        {
            get;
            private set;
        }

        /// <summary>
        /// The place the purchase was made
        /// </summary>
        public string Place
        {
            get { return place; }
        }
        private string place;

    }
}
