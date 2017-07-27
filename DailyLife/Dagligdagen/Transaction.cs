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
        public Transaction(Product product, decimal amountOfMoney, DateTime date, uint iD, string comment)
        {
            AmountOfMoney = amountOfMoney;
            Date = date;
            this.iD = iD;
            this.product = product;
            this.comment = comment;
        }
        private uint iD;
        /// <summary>
        /// The transaction ID
        /// </summary>
        public uint ID
        {
            get { return iD; }
        }
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

        /// <summary>
        /// The amount of money used in each transaction 
        /// </summary>
        public abstract decimal AmountOfMoney { get; set; }

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

        protected string comment;

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

    }
}