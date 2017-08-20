using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// A transaction containing products
    /// </summary>
    public abstract class MainTransaction
    { 
        private int iD;
        /// <summary>
        /// The unique head transaction ID
        /// </summary>
        public int ID
        {
            get { return iD; }
        }

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

        /// <summary>
        /// a comment on the transaction
        /// </summary>
        public string comment;

        /// <summary>
        /// The price of the whole transaction
        /// </summary>
        public decimal amountOfMoney
        {
            private set;
            get;
        }
        
        public MainTransaction(string comment, DateTime date, int iD, decimal amountOfMoney)
        {
            this.amountOfMoney = amountOfMoney;
            this.comment = comment;
            this.date = date;
            this.iD = iD;
        }

    }
}
