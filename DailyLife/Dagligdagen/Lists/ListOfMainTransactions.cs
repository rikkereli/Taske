using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class ListOfMainTransactions : ListType, IEnumerable<MainTransaction>
    {
        #region constructor
        /// <summary>
        /// Makes it possible to add a list when construction the list, so there is no problems with ID
        /// </summary>
        /// <param name="list"></param>
        public ListOfMainTransactions(List<MainTransaction> listOfTransactions, IUserinterface uI)
        {
            UI = uI;
            foreach (MainTransaction transaction in listOfTransactions)
            {
                //So there is an unique iD
                foreach (MainTransaction transactionAlreadyAdded in this.listOfMainTransactions)
                {
                    if (transactionAlreadyAdded.ID == iD)
                    {
                        throw new IDAlreadyTakenException($"The product ID {iD} is already taken");
                    }
                }

                this.listOfMainTransactions.Add(transaction);
                //Make sure that two ID's will never be the same
                if (transaction.ID >= this.iD)
                {
                    this.iD = transaction.ID + 1;
                }
            }
        }
        /// <summary>
        /// Makes it possible to not add a list when construction a list of transactions
        /// </summary>
        public ListOfMainTransactions(IUserinterface UI)
        {
            this.UI = UI;
        }
        #endregion

        #region Fields and proporties
        /// <summary>
        /// The userinterface used
        /// </summary>
        public IUserinterface UI
        {
            get;
            private set;
        }
        private List<MainTransaction> listOfMainTransactions = new List<MainTransaction>();

        private MainTransaction latestAdded;
        /// <summary>
        /// Get the latest added transaction.
        /// </summary>
        public MainTransaction LatestAdded
        {
            get { return latestAdded; }
        }
        #endregion

        #region ChangeList

        /// <summary>
        /// Add a tranaction to the list of transactions
        /// </summary>
        /// <param name="price"></param>
        /// <param name="product"></param>
        /// <param name="discountAmount"></param>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        public void AddBuyMainTransaction(decimal price, DateTime date, decimal discountAmount, string comment, string place)
        {
            //TODO implement exception
            try
            {
                listOfMainTransactions.Add(new MainBuyTransaction(comment, date, iD, price, place, this.UI));
                
            }
            catch
            {
                throw new FormatException("The format of the buytransaction was somehow wrong");
            }
        }
        #endregion


        #region Info
        /// <summary>
        /// Get the number of transactions on the list
        /// </summary>
        public int NumberOfTransactions
        {
            get { return listOfMainTransactions.Count; }
        }

        /// <summary>
        /// Get a readonly copy of list
        /// </summary>
        public IEnumerable<MainTransaction> TransactionList
        {
            get { return listOfMainTransactions; }
        }
        #endregion

        #region search
        /// <summary>
        /// Find a transaction by ID in the list of transactions
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public MainTransaction FindMainTransactionByID(uint ID)
        {
            foreach (MainTransaction transaction in listOfMainTransactions)
            {
                if (transaction.ID == ID)
                {
                    return transaction;
                }
            }
            return null;
        }
        #endregion

        #region IEnumarable
        public IEnumerator<MainTransaction> GetEnumerator()
        {
            return listOfMainTransactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listOfMainTransactions.GetEnumerator();
        }

        #endregion
    }
}
