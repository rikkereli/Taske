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
        public void AddTransaction(decimal price, string productName, decimal discountAmount, DateTime date, ProductType productType, int amount)
        {
            try
            {
                listOfTransactions.Add(new BuyTransaction(price, productName, discountAmount, iD, date, amount, productType));
                iD++;
            }
            //Will probably implement this later. Don't know what to put here now
            catch (Exception)
            {

            }
        }

    }
}