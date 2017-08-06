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
    public class DailyLifeSystem
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
        /// <param name="fileWithProductPlacement"></param>
        /// <param name="fileWithDiscardedProductPlacement"></param>
        /// <param name="fileWithTransactionsPlacement"></param>
        /// <param name="fileWithDiscardedTransactionsPlacement"></param>
        public DailyLifeSystem(string fileWithProductPlacement, string fileWithDiscardedProductPlacement, string fileWithTransactionsPlacement, string fileWithDiscardedTransactionsPlacement)
        {
            //Makes a list of products with the content of a file
            listOfProducts = new ListOfProducts(ReadFromFiles.ReadFromProductfileToListOfProducts(fileWithProductPlacement, fileWithDiscardedProductPlacement), fileWithProductPlacement);
            //Makes a list of Transactions with the content of a file and the list of products
            listOfTransactions = new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(fileWithTransactionsPlacement, listOfProducts),listOfTransactionsFilePlacement);

            //Save the placements of the paths
            listOfProductsFilePlacement = fileWithProductPlacement;
            listOfTransactionsFilePlacement = fileWithTransactionsPlacement;
            listOfDiscardedProductFilePlacement = fileWithDiscardedProductPlacement;
            listOfDiscardedTransactionsFilePlacement = fileWithDiscardedTransactionsPlacement;
        }


    }
}
