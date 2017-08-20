using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public interface IUserinterface 
    {

        ListOfProducts ProductList { get; }

        ListOfMainTransactions MainTransactionList { get; }

        /// <summary>
        /// Make this list while you are making a bigger transaction
        /// </summary>
        ListOfTransactions TempTransaction { get; set; }

        void AddProductToProductTable(int iD, string productName, string typeOfProduct, string typeOfUnit);

        void AddMainBuyTransactionToTransactionTable(int iD, DateTime date, decimal price, string comment, string place);

        void AddProductToMainBuyTransactionTable(int productID, int transactionID, string productName, int amountOfProduct, string typeOfProduct, decimal discountAmount, decimal price, string comment, decimal amountOfUnitInProduct);


    }
}
