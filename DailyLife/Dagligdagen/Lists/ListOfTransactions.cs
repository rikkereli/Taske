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
        public ListOfTransactions(List<AddProductToTransaction> listOfTransactions, string path)
        {
            pathToFile = path;
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
        public ListOfTransactions(string path)
        {
            pathToFile = path;
        }
        #endregion

        #region Fields and proporties
        /// <summary>
        /// The path to the file where the transaction is
        /// </summary>
        string pathToFile;
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
        /// <param name="amount"></param>
        public void AddBuyTransaction(decimal price, Product product, decimal discountAmount, DateTime date, int amount, string comment, string productName, decimal amountOfUnitInThis, uint transactionID)
        {
            //TODO make it write to file
            try
            {
                BuyTransaction transaction = new BuyTransaction(price, product, discountAmount, iD, date, amount, comment, productName, amountOfUnitInThis, transactionID);
                //TODO make the add transaction be different if it is an insert
                listOfTransactions.Add(transaction);
                iD++;
                latestAdded = transaction;
                StreamWriter streamWriter = new StreamWriter(pathToFile, true);
                streamWriter.WriteLine(transaction.FileFormat());
                streamWriter.Close();
            }
            //TODO Will probably implement this later. Don't know what to put here now
            catch (Exception)
            {

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