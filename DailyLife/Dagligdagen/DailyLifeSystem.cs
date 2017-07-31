using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// The class that contains the system
    /// </summary>
    class DailyLifeSystem
    {
        #region Lists
        /// <summary>
        /// The list of products to this system
        /// </summary>
        public ListOfProducts listOfProducts;
        /// <summary>
        /// The list of transactions to this system
        /// </summary>
        public ListOfTransactions listOfTransactions;
        #endregion

        #region Placements
        string listOfProductsFilePlacement;
        string listOfTransactionsFilePlacement;
        string listOfDiscardedTransactionsFilePlacement;
        string listOfDiscardedProductFilePlacement;
        #endregion

        /// <summary>
        /// The constructor, nedds the lists
        /// </summary>
        /// <param name="listOfProductPlacement"></param>
        /// <param name="listOfDiscardedProductPlacement"></param>
        /// <param name="listOfTransactionsPlacement"></param>
        /// <param name="listOfDiscardedTransactionsPlacement"></param>
        public DailyLifeSystem(string listOfProductPlacement, string listOfDiscardedProductPlacement, string listOfTransactionsPlacement, string listOfDiscardedTransactionsPlacement)
        {
            //Makes a list of products with the content of a file
            listOfProducts = new ListOfProducts(ReadFromFiles.ReadFromProductfileToListOfProducts(listOfProductPlacement, listOfDiscardedProductPlacement));
            //Makes a list of Transactions with the content of a file and the list of products
            listOfTransactions = new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(listOfTransactionsPlacement, listOfProducts));

            //Save the placements of the paths
            listOfProductsFilePlacement = listOfProductPlacement;
            listOfTransactionsFilePlacement = listOfTransactionsPlacement;
            listOfDiscardedProductFilePlacement = listOfDiscardedProductPlacement;
            listOfDiscardedTransactionsFilePlacement = listOfDiscardedTransactionsPlacement;
        }


    }
}
