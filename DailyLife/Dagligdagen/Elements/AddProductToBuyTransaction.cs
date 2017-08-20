using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    class AddProductToBuyTransaction : AddProductToTransaction
    {
        #region Proporties
        #region Price
        private decimal price;
        /// <summary>
        /// The price of each product
        /// </summary>
        public override decimal AmountOfMoney
        {
            get { return price; }
            set
            {
                //Makes sure that the amount is positive
                if (value >= 0)
                {
                    price = value;
                }
            }
        }
        #endregion
        #region DiscoundAmount
        private decimal discountAmount;
        /// <summary>
        /// The discount amount of the item 
        /// </summary>
        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set
            {
                // Make sure the discount amount is not negative, because it would not make sense 
                if (value >= 0)
                {
                    discountAmount = value;
                }
            }
        }
        #endregion
        #region Amount
        private int amount;
        /// <summary>
        /// Amount of products bought
        /// </summary>
        public int Amount
        {
            get { return amount; }
            set
            {
                //Makes sure there is a positive amount
                if (value > 0)
                {
                    amount = value;
                }
                else
                {
                    throw new InvalidArgumentException($"Your amount can't be {value}");
                }
            }
        }
        #endregion
        #region ProductName
        private string productName;
        /// <summary>
        /// Is made so you still will be able to find out what the product was, even if there is something wrong with the ID system
        /// </summary>
        public string ProductName
        {
            get { return productName; }
        }
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// Standard constructor
        /// </summary>
        /// <param name="price"></param>
        /// <param name="productName"></param>
        /// <param name="discountAmount"></param>
        /// <param name="iD"></param>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        public AddProductToBuyTransaction(decimal price, Product product, decimal discountAmount, int iD, int amount, string comment, string productName, decimal amountOfProductUnit, int transactionID) : base (product, price, iD, comment, amountOfProductUnit,transactionID)
        {
            DiscountAmount = discountAmount;
            Amount = amount;
            this.productName = ProductName;
        }
        #endregion

        /// <summary>
        /// The format the product is to be written with in the file
        /// </summary>
        /// <returns></returns>
        public override string FileFormat()
        {
            return $"Buy;{ThisElementID};{Product.ID};{price};{ProductName};{comment};{discountAmount};{amount}";
        }
    }
}
