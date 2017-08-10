using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dagligdagen
{
    /// <summary>
    /// The class that communicates with the person
    /// </summary>
    public class UserInterfaceConsole : IUserinterface
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
        public UserInterfaceConsole(DailyLifeSystem system)
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
            DisplayStartMenu();
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
                unitType = ParseStringToType.UnitType(InvalidArgument(writtenUnitType, "a unittype"));
            }
            //Make the producttype
            Console.WriteLine("Enter the producttype");
            string writtenProductType = Console.ReadLine();
            productType = ParseStringToType.ProductType(writtenProductType);
            while (productType == ProductType.NotFound)
            {
                //Makes sure a valid producttype is added
                productType = ParseStringToType.ProductType(InvalidArgument(writtenProductType, "producttype"));
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
            AddProductToBuyTransaction();

            
        }
        public void AddProductToBuyTransaction()
        {
            //Information
            decimal price;
            Product product = null;
            decimal discoundAmount;
            DateTime date;
            int amount;
            string comment;
            string productName;

            Console.WriteLine("Enter price");
            //Make sure a valid price is added
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("The inserted text is not a valid number, please try again");
            }
            Console.WriteLine("Enter product name"); //TODO change everything to lower when seaching name
            do
            {
                product = system.listOfProducts.FindProductByName(Console.ReadLine());
                if(product == null)
                {
                    Console.WriteLine("The productname is not in the database, try again");
                }
                //Make the productname so the product can be found again if there is trouble with the id's
            }
            while (product == null);
            //TODO make product find function
            productName = product.PrimaryProductName;
            //Make sure a valid discountamound is added
            Console.WriteLine("Enter discount amount");
            while (!decimal.TryParse(Console.ReadLine(), out discoundAmount))
            {
                Console.WriteLine("The inserted text is not a valid number, please try again");
            }
            //Make a valid datetime
            date = MakeADatetimeWithUserInput();

            //Make sure a valid amount is added
            Console.WriteLine("Enter amount of products bought");
            while (!int.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The inserted text is not a valid number, please try again");
            }
            Console.WriteLine("Enter comment");
            comment = Console.ReadLine();

            system.listOfTransactions.AddBuyTransaction(price, product, discoundAmount, date, amount, comment, productName);
        }
        /// <summary>
        /// Used to exit program
        /// </summary>
        public void Exit()
        {
            Console.WriteLine("You have choosen to exit program. Have a nice day");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        /// <summary>
        /// Is used to make a datetime from user input
        /// </summary>
        /// <returns></returns>
        static public DateTime MakeADatetimeWithUserInput()
        {
            int day,
                month,
                year,
                minute,
                hour,
                //I don't really think it is neccesary for the user to write the second
                //TODO Make common datetime to whole transaction 
                second = 0;

            //Make sure a year is added
            Console.WriteLine("Year");
            while (!(int.TryParse(Console.ReadLine(), out year) && (year >= 1900 && year <= (DateTime.Now.Year + 100))))
            {
                Console.WriteLine("The inserted text is not a valid year, please try again");
            }
            //Make sure a valid month is added
            Console.WriteLine("Month:");
            while (!(int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12))
            {
                Console.WriteLine("The inserted text is not a valid month, please try again");
            }
            //Make sure a valid day is added
            Console.WriteLine("Day:");
            while (!(int.TryParse(Console.ReadLine(), out day) && (day >= 1 && day <= DateTime.DaysInMonth(year, month))))
            {
                Console.WriteLine("The inserted text is not a valid number, please try again");
            }
            //Make sure a valid minute is added
            Console.WriteLine("Minute:");
            while (!(int.TryParse(Console.ReadLine(), out minute) && (minute >= 0 && minute <= 60)))
            {
                Console.WriteLine("The inserted text is not a valid minute, please try again");
            }
            //Make sure a hour is added
            Console.WriteLine("Hour");
            while (!(int.TryParse(Console.ReadLine(), out hour) && (hour >= 0 && hour <= 24)))
            {
                Console.WriteLine("The inserted text is not a valid hour, please try again");
            }
            return new DateTime(year, month, day, hour, minute, second);
        }


        #endregion

        #region Writeout
        /// <summary>
        /// Writes out all products
        /// </summary>
        public void WriteOutProducts()
        {
            Console.WriteLine("The products are as follows:");
            foreach(Product product in system.listOfProducts)
            {
                Console.WriteLine(product);
            }
        }
        //TODO Seach the transactions more specifictly
        /// <summary>
        /// Writes out all transactions 
        /// </summary>
        public void WriteOutTransactions()
        {
            Console.WriteLine("The transactions are as follows:");
            foreach (AddProductToTransaction transaction in system.listOfTransactions)
            {
                Console.WriteLine(transaction);
            }
        }
        #endregion
        #region Navigate menu
        //TODO his is far from the optimal solution , but I will change it if I have time. An alternative solution could be to make a menu class
        /// <summary>
        /// Displays the start menu choices 
        /// </summary>
        public void DisplayStartMenu()
        {
            Console.WriteLine("Hello and welcome to the daily life tracker. Please choose an option");
            //Writes the menu out
            int highlightedMenuitem = 1;
            //Represents the choosen menu item, because highlighted menu item becomes 0
            int choosenItem = 0;
            //Breaks the loop when user choose item
            #region Writeout
            while (highlightedMenuitem != 0)
            {
                Console.Clear();
                int highestNumberOfMenuItems = 0;
                int countTheWrittenItems = 0;
                String[] arrayOfMenuItem = new string[] { "Make transaction", "Make product", "See products", "See transactions", "Exit"}; //TODO make watch profile
                Console.WriteLine("To use the system, use one of the following commands");
                foreach (String menuItem in arrayOfMenuItem)
                {

                    if (highlightedMenuitem == countTheWrittenItems + 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(menuItem);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.WriteLine(menuItem);
                    }
                    countTheWrittenItems++;
                    highestNumberOfMenuItems++;

                }
                choosenItem = highlightedMenuitem;
                HandleInput(ref highlightedMenuitem, highestNumberOfMenuItems);
            }
            #endregion
            //I would normally have made an enum type to switch on, to make the code more readable. Will do this if I find time
            switch (choosenItem)
            {
                case 1:
                    AddBuyTransaction();
                    break;
                case 2:
                    AddProduct();
                    break;
                case 3:
                    WriteOutProducts();
                    break;
                case 4:
                    WriteOutTransactions();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("something went wrong");
                    break;
            }
            Console.ReadKey();
            DisplayStartMenu();
        }
        /// <summary>
        /// Handles input from menu makers
        /// </summary>
        /// <param name="currentCount"></param>
        /// <param name="highestCount"></param>
        /// <param name="product"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public void HandleInput(ref int currentCount, int highestCount)
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    //Make sure that the current count can't be less than 1
                    if (currentCount > 1)
                    {
                        currentCount--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    //Make sure that the current count can't be higher than the number of elements
                    if (currentCount < highestCount)
                    {
                        currentCount++;
                    }
                    break;
                case ConsoleKey.Enter:
                    //break the while loop
                    currentCount = 0;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region Messages

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
