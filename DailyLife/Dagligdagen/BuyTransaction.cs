﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    class BuyTransaction : Transaction
    {
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
                if (value <= 0)
                {
                    price = value;
                }
            }
        }

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
        private int amount;
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


        /// <summary>
        /// Standard constructor
        /// </summary>
        /// <param name="price"></param>
        /// <param name="productName"></param>
        /// <param name="discountAmount"></param>
        /// <param name="iD"></param>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        public BuyTransaction(decimal price, string productName, decimal discountAmount, uint iD, DateTime date, int amount, ProductType productType) : base (productType, price, date, iD)
        {
            ProductName = productName;
            DiscountAmount = discountAmount;
            Amount = amount;
        }
    }
}
