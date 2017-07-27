using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// Make sure the list of transactions is secure, and that every transaction has an unique ID 
    /// </summary>
    public class ListOfTransactions : List, IEnumerable<Transaction>
    {
        /// <summary>
        /// Makes it possible to add a list when construction the list, so there is no problems with ID
        /// </summary>
        /// <param name="list"></param>
        public ListOfTransactions(List<Transaction> listOfTransactions)
        {
            foreach (Transaction transaction in listOfTransactions)
            {
                //So there is an unique iD
                foreach (Transaction transactionAlreadyAdded in this.listOfTransactions)
                {
                    if (transactionAlreadyAdded.ID == iD)
                    {
                        throw new IDAlreadyTakenException($"The product ID {iD} is already taken");
                    }
                }

                this.listOfTransactions.Add(transaction);
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
        public ListOfTransactions() { }

        private List<Transaction> listOfTransactions = new List<Transaction>();

        /// <summary>
        /// Add a tranaction to the list of transactions
        /// </summary>
        /// <param name="price"></param>
        /// <param name="product"></param>
        /// <param name="discountAmount"></param>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        public void AddBuyTransaction(decimal price, Product product, decimal discountAmount, DateTime date, int amount, string comment, string productName)
        {
            try
            {
                //TODO make the add transaction be different if it is an insert
                listOfTransactions.Add(new BuyTransaction(price, product, discountAmount, iD, date, amount, comment, productName));
                iD++;
            }
            //TODO Will probably implement this later. Don't know what to put here now
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Get the number of transactions on the list
        /// </summary>
        public int NumberOfTransactions
        {
            get { return listOfTransactions.Count; }
        }

        /// <summary>
        /// Find a transaction by ID in the list of transactions
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Transaction FindTransactionByID(uint ID)
        {
            foreach (Transaction transaction in listOfTransactions)
            {
                if (transaction.ID == ID)
                {
                    return transaction;
                }
            }
            return null;
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return listOfTransactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listOfTransactions.GetEnumerator();
        }
    }
}