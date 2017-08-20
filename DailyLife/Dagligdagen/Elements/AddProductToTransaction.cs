using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// A common for all types of transactiona
    /// </summary>
    public abstract class AddProductToTransaction
    {
        #region Constructor
        public AddProductToTransaction(Product product, decimal amountOfMoney, int thisProductID, string comment, decimal amountOfUnit, int transactionID)
        {
            AmountOfMoney = amountOfMoney;
            this.thisElementID = thisProductID;
            this.product = product;
            this.comment = comment;
            this.transactionID = transactionID;
            this.amountOfUnitInEachElement = amountOfUnit;
        }
        #endregion

        #region Proporty
        #region ID
        private int thisElementID;
        /// <summary>
        /// The transaction ID
        /// </summary>
        public int ThisElementID
        {
            get { return thisElementID; }
        }

        private int transactionID;
        /// <summary>
        /// The ID for the transaction this belongs to
        /// </summary>
        public int TransactionID
        {
            get { return transactionID;}
        }
        #endregion

        private decimal amountOfUnitInEachElement;
        /// <summary>
        /// The amount of the products unit there is in each element of this product
        /// </summary>
        public decimal AmountOfUnitInEachElement
        {
            get { return amountOfUnitInEachElement; }
        }

        #region Product
        protected Product product;
        /// <summary>
        /// The type of product
        /// </summary>
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
            }
        }
        #endregion

        #region AmountOfMoney
        /// <summary>
        /// The amount of money used in each transaction 
        /// </summary>
        public abstract decimal AmountOfMoney { get; set; }
        #endregion

        #region Comment
        protected string comment;
        /// <summary>
        /// An optional comment the user can make
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set
            {
                if (value != null)
                {
                    comment += $" {value}";
                }
            }
        }
        #endregion
        #endregion

        #region String 
        /// <summary>
        /// To make it easier to understand the ToString
        /// </summary>
        /// <returns></returns>
        public static string TableExplanation()
        {
            return "ID | Product name | Amount of money | Date | Comment";
        }
        public override string ToString()
        {
            return $"{thisElementID} | {product.PrimaryProductName} | {AmountOfMoney} | {comment}";
        }
        /// <summary>
        /// The format the transaction is to be written with in the file
        /// </summary>
        /// <returns></returns>
        public abstract string FileFormat();
        #endregion
    }
}