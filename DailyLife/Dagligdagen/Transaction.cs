using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    public abstract class Transaction
    {
        public Transaction(Product product, decimal amountOfMoney, DateTime date, uint iD)
        {
            AmountOfMoney = amountOfMoney;
            Date = date;
            ID = iD;
        }
        private uint iD;
        /// <summary>
        /// The transaction ID
        /// </summary>
        public uint ID
        {
            get { return iD; }
            set
            {
                iD = ID;
            }
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

    }
}