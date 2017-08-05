using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// The class that communicates with the person
    /// </summary>
    class UserInterface : IUserinterface
    {
        #region Proporties
        //The daily life system the UI is connected to
        private DailyLifeSystem system;

        public DailyLifeSystem System
        {
            get { return system; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Make the system
        /// </summary>
        public UserInterface(DailyLifeSystem system)
        {
            this.system = system;
        } 
        #endregion

        #region Mechanics
        /// <summary>
        /// The function that starts the system
        /// </summary>
        public void Run()
        {
            HelloMessage();
        }
        /// <summary>
        /// Navigate in the menu
        /// </summary>
        public void Navigate()
        {

        }
        /// <summary>
        /// Is called when some invalid argument is added in add product
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="whatIsWrong"></param>
        /// 
        public string InvalidArgument(string argument, string whatIsWrong)
        {
            Console.WriteLine($"The word {argument} is not {whatIsWrong}, please enter another");
            return Console.ReadLine();
        }
        #region Add Product

        /// <summary>
        /// Add a product to the products
        /// </summary>
        public void AddProduct()
        {
            string productName;

            UnitType unitType;
            ProductType productType;

            Console.WriteLine("Enter the product name: ");
            productName = Console.ReadLine();

            //Makes the unittype
            Console.WriteLine("Enter the unittype: ");
            string writtenUnitType = Console.ReadLine();
            unitType = ParseStringToType.UnitType(writtenUnitType);
            while (unitType == UnitType.notFound)
            {
                //MAkes sure a valid unittype is added
                ParseStringToType.UnitType(InvalidArgument(writtenUnitType, "a unittype"));
            }
            //Make the producttype
            Console.WriteLine("Enter the producttype");
            string writtenProductType = Console.ReadLine();
            productType = ParseStringToType.ProductType(writtenProductType);
            while (productType == ProductType.NotFound)
            {
                //Makes sure a valid producttype is added
                ParseStringToType.ProductType(InvalidArgument(writtenProductType, "producttype"));
            }

            system.listOfProducts.AddProduct(productName, unitType, productType);
        }
        #endregion

        #region Add transaction
        /// <summary>
        /// Add a purchase 
        /// </summary>
        public void AddBuyTransaction()
        {
            //TODO Make big transactions without all the products 


            
        }
        public void AddProductToTransaction()
        {
            //Information
            decimal price;
            Product product;
            decimal discoundAmount;
            DateTime date;
            int amount;
            string comment;
            string productName;
        }
        #endregion

        #endregion

        #region Messages
        /// <summary>
        /// The first message the user gets
        /// </summary>
        public void HelloMessage()
        {
            Console.WriteLine("Hello and welcome to the daily life tracker. Please choose an option");
        }
        /// <summary>
        /// Message that asks you to add product
        /// </summary>
        public void AddProductMessage()
        {
            Console.WriteLine("Please enter the bought product");
        }
        #endregion
    }
}
