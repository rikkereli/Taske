using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// A common for all types of transactiona
    /// </summary>
    public abstract class Transaction
    {
        #region Constructor
        public Transaction(Product product, decimal amountOfMoney, DateTime date, uint iD, string comment)
        {
            AmountOfMoney = amountOfMoney;
            Date = date;
            this.iD = iD;
            this.product = product;
            this.comment = comment;
        }
        #endregion

        #region Proporty
        #region ID
        private uint iD;
        /// <summary>
        /// The transaction ID
        /// </summary>
        public uint ID
        {
            get { return iD; }
        }
        #endregion

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

        #region Date
        protected DateTime date;
        /// <summary>
        /// The date of the transaction
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != null)
                {
                    date = value;
                }
                else
                {
                    throw new ArgumentNullException("The date of a transaction can't be null");
                }
            }
        }
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
            return $"{iD} | {product.PrimaryProductName} | {AmountOfMoney} | {Date} | {comment}";
        }
        /// <summary>
        /// The format the transaction is to be written with in the file
        /// </summary>
        /// <returns></returns>
        public abstract string FileFormat();
        #endregion
    }
}