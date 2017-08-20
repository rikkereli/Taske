using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// Make sure the list of transactions is secure, and that every transaction has an unique ID 
    /// </summary>
    public class ListOfTransactions : ListType, IEnumerable<AddProductToTransaction>
    {
        #region constructor
        /// <summary>
        /// Makes it possible to add a list when construction the list, so there is no problems with ID
        /// </summary>
        /// <param name="list"></param>
        public ListOfTransactions(List<AddProductToTransaction> listOfTransactions, IUserinterface UI)
        {
            this.UI = UI;
            foreach (AddProductToTransaction transaction in listOfTransactions)
            {
                //So there is an unique iD
                foreach (AddProductToTransaction transactionAlreadyAdded in this.listOfTransactions)
                {
                    if (transactionAlreadyAdded.ThisElementID == iD)
                    {
                        throw new IDAlreadyTakenException($"The product ID {iD} is already taken");
                    }
                }

                this.listOfTransactions.Add(transaction);
                //Make sure that two ID's will never be the same
                if (transaction.ThisElementID >= this.iD)
                {
                    this.iD = transaction.ThisElementID + 1;
                }
            }
        }
        /// <summary>
        /// Makes it possible to not add a list when construction a list of transactions
        /// </summary>
        public ListOfTransactions(IUserinterface UI)
        {
            this.UI = UI;
        }
        #endregion

        #region Fields and proporties
        /// <summary>
        /// The UI this transaction is in
        /// </summary>
        IUserinterface UI;
        private List<AddProductToTransaction> listOfTransactions = new List<AddProductToTransaction>();

        private AddProductToTransaction latestAdded;
        /// <summary>
        /// Get the latest added transaction.
        /// </summary>
        public AddProductToTransaction LatestAdded
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
        /// <param name="amountOfProduct"></param>
        public void AddProductToMainBuyTransactionOnMakingTransaction(decimal price, Product product, decimal discountAmount, int amountOfProduct, string comment, string productName, decimal amountOfUnitInThis, int transactionID, string typeOfProduct)
        {
            try
            {
                listOfTransactions.Add(new AddProductToBuyTransaction(price, product, discountAmount, iD, amountOfProduct, comment, productName, amountOfUnitInThis, transactionID));
                UI.AddProductToMainBuyTransactionTable(iD, transactionID, productName, amountOfProduct, typeOfProduct, discountAmount, price, comment, amountOfUnitInThis);
                iD++;
            }
            catch
            {
                throw new FormatException("The format of the product is wrong");
            }
        }
        #endregion

        #region Info
        /// <summary>
        /// Get the number of transactions on the list
        /// </summary>
        public int NumberOfTransactions
        {
            get { return listOfTransactions.Count; }
        }

        /// <summary>
        /// Get a readonly copy of list
        /// </summary>
        public IEnumerable<AddProductToTransaction> TransactionList
        {
            get { return listOfTransactions; }
        }
        #endregion

        #region search
        /// <summary>
        /// Find a transaction by ID in the list of transactions
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public AddProductToTransaction FindTransactionByID(uint ID)
        {
            foreach (AddProductToTransaction transaction in listOfTransactions)
            {
                if (transaction.ThisElementID == ID)
                {
                    return transaction;
                }
            }
            return null;
        }
        #endregion

        #region IEnumarable
        public IEnumerator<AddProductToTransaction> GetEnumerator()
        {
            return listOfTransactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listOfTransactions.GetEnumerator();
        }
        #endregion
    }
}