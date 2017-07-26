using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// Make sure the list of transactions is secure, and that every transaction has an unique ID 
    /// </summary>
    public class ListOfTransactions : List
    {

        private List<BuyTransaction> listOfTransactions = new List<BuyTransaction>();
        /// <summary>
        /// Add a tranaction to the list of transactions
        /// </summary>
        /// <param name="price"></param>
        /// <param name="product"></param>
        /// <param name="discountAmount"></param>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        public void AddTransaction(decimal price, Product product, decimal discountAmount, DateTime date, int amount, string comment)
        {
            try
            {
                //TODO make the add transaction be different if it is an insert
                listOfTransactions.Add(new BuyTransaction(price, product, discountAmount, iD, date, amount, comment));
                iD++;
            }
            //Will probably implement this later. Don't know what to put here now
            catch (Exception)
            {

            }
        }

    }
}