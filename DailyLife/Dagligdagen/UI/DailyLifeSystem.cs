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

        /// <summary>
        /// The constructor, nedds the lists
        /// </summary>
        /// <param name="fileWithProductPlacement"></param>
        /// <param name="fileWithDiscardedProductPlacement"></param>
        /// <param name="fileWithTransactionsPlacement"></param>
        /// <param name="fileWithDiscardedTransactionsPlacement"></param>
        public DailyLifeSystem()
        {

        }


    }
}
