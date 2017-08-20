using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class SqlitefUI : IUserinterface
    {
        #region Counstructor
        public SqlitefUI(String productTableName, string addProductToMainTransactionTableName, string addProductToTransactionTableName, string databaseLocation)
        {
            sqlite = new SQLiteConnection(databaseLocation);
            DataTable TableWithProducts = InteractWithDatabase.SelectQuery($"Select * From {productTableName}", sqlite);
            this.productTableName = productTableName;
            this.addProductToTransactionTableName = addProductToTransactionTableName;
            this.addProductToTransactionTableName = mainBuyTransactionTableName;
            productList = new ListOfProducts(InteractWithDatabase.ProductTableToListOfProducts(TableWithProducts), this);
            transactionList = new ListOfTransactions(null);
        }
        #endregion

        #region Fields and props
        private ListOfProducts productList;
        private ListOfTransactions transactionList;

        /// <summary>
        /// Make sure it is the right producttable
        /// </summary>
        private string productTableName;
        /// <summary>
        /// Make sure it is the right main transaction table
        /// </summary>
        private string mainBuyTransactionTableName;
        /// <summary>
        /// Make sure it is the right add product to transacton table name
        /// </summary>
        private string addProductToTransactionTableName;


        private SQLiteConnection sqlite;
        /// <summary>
        /// The list of products to the system
        /// </summary>
        public ListOfProducts ProductList
        {
            get
            {
                return productList;
            }
        }


        public ListOfMainTransactions MainTransactionList
        {
            get;
            private set;
        }

        public ListOfTransactions TempTransaction
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Add elements to table
        /// <summary>
        /// Add product to list of products
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="productName"></param>
        /// <param name="typeOfProduct"></param>
        /// <param name="typeOfUnit"></param>
        public void AddProductToProductTable(int iD, string productName, string typeOfProduct, string typeOfUnit)
        {
            //Write the new product to table
            InteractWithDatabase.SelectQuery($"INSERT INTO {productTableName} VALUES({iD},'{productName}','{typeOfProduct}','{typeOfUnit}')", sqlite);
        }

        /// <summary>
        /// Add main transaction to transaction table
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="productName"></param>
        /// <param name="typeOfProduct"></param>
        /// <param name="typeOfUnit"></param>
        public void AddMainBuyTransactionToTransactionTable(int iD, DateTime date, decimal price, string comment, string place)
        {
            //Write the new product to table
            InteractWithDatabase.SelectQuery($"INSERT INTO {mainBuyTransactionTableName} VALUES({iD},'{place}','{comment}','{price}, '{date}')", sqlite);
        }
        /// <summary>
        /// Add product to main transaction table
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="productName"></param>
        /// <param name="typeOfProduct"></param>
        /// <param name="typeOfUnit"></param>
        public void AddProductToMainBuyTransactionTable(int productID, int transactionID, string productName, int amountOfProduct,string typeOfProduct, decimal discountAmount, decimal price, string comment, decimal amountOfUnitInProduct)
        {
            //Write the new product to table
            InteractWithDatabase.SelectQuery($"INSERT INTO {addProductToTransactionTableName} VALUES({productID},{transactionID},'{comment}',{price},{amountOfProduct},{amountOfUnitInProduct},{discountAmount},'{productName}','{typeOfProduct}')", sqlite);
        }
        #endregion


    }
}
