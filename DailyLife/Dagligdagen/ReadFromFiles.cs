using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// Read from the files in the database
    /// </summary>
    public static class ReadFromFiles
    {
        #region ProductFiles
        /// <summary>
        /// Takes the file with products and read it in to a list of products to use at runtime
        /// </summary>
        /// <returns></returns>
        public static ListOfProducts ReadFromProductfileToListOfProducts() { return null; }
        #endregion

        #region InformationPlacements
        // The placements of the information in the transaction files, as it would be in an array. Makes it more flexible
        private static int transactionTypePlacementTransaction,
                           TransactioniDPlacementTransaction = 1,
                           productIDPlacementTransaction = 2,
                           datePlacementTransaction = 3,
                           amountOfMoneyPlacementTransaction = 4,
                           productNamePlacementTransaction = 5,
                           commentPlacementTransaction = 6,
                           discountAmountPlacementTransaction = 7,
                           amountOfProductsBoughtPlacementTransaction = 8;
        #endregion

        #region TransactionFiles
        /// <summary>
        /// Takes the file with transactions and reads them in to a list of transactions to use at runtime
        /// </summary>
        /// <returns></returns>
        public static ListOfTransactions ReadFromTransactionFileToListOfTransactions(string path, ListOfProducts listOfProducts)
        {
            //The list of transactions to be send as an argument in the constructor of the returned ListOfTransactions
            List<Transaction> listOfTransactions = new List<Transaction>();
            //The number of informationslots in te list
            int numberOfInformationslots = 9;
            //Read the text from the files into an array of strings, so every transaction has a entrance
            string[] lines = System.IO.File.ReadAllLines(path);
            //Makes sure the first describing line is not translated.
            bool firstIsDone = false;
            foreach (string line in lines)
            {
                //TODO better security
                if (firstIsDone)
                {
                    try
                    {
                        string[] transactionDetails = line.Split(';');
                        if (transactionDetails.Length == numberOfInformationslots)
                        {
                            if (transactionDetails[transactionTypePlacementTransaction] == "Buy")
                            {

                                MakeBuyTransaction(listOfTransactions, listOfProducts, transactionDetails);

                            }
                        }
                        else
                        {
                            //Makes sure the line is added to a list of broken transactions
                            throw new FormatException($"The number of segments in the line is wrong. It should be {numberOfInformationslots} but it is {transactionDetails.Length} \n The line is {line}");
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"The string {line} is not a valid transaction. The (first) thing wrong is {ex}");
                    }
                }
                else
                {
                    //Shows that the first is done, so the code will go into the if statement.
                    firstIsDone = true;
                }
            }

            return new ListOfTransactions(listOfTransactions);
        }
        /// <summary>
        /// Make the ReadFromTransactionfileToListOfTransactios more readable
        /// </summary>
        public static void MakeBuyTransaction(List<Transaction> listOfTransactions, ListOfProducts listOfProducts, String[] transactionDetails)
        {
            //I declare the variables here, to make sure they do not contain information from last line
            //The transaction ID
            uint transactionID;
            //The product
            Product product;
            //The date of the transaction
            DateTime transactiondate;
            //The price of the transaction 
            decimal price;
            //The discount given to the product
            decimal discountAmount;
            //The product description 
            string comment;
            //The amount of products bought
            int amountOfProducts;
            //The name of the product in case something should go wrong with the system
            string nameOfProduct;

            try
            {
                //The transaction ID, is used to identify the transaction later on
                transactionID = UInt32.Parse(transactionDetails[TransactioniDPlacementTransaction]);
            }
            catch (FormatException)
            {
                throw new FormatException($"The format of the transactionID {transactionDetails[TransactioniDPlacementTransaction]} is invalid. ");
            }
            try
            {
                //The product ID, is used to find the relevant product
                uint productID = UInt32.Parse(transactionDetails[productIDPlacementTransaction]);
                product = listOfProducts.FindProductByID(productID);
                if (product == null)
                {
                    throw new ElementDoesNotExistException($"Product with ID {productID} does not excist");
                }
            }
            catch (FormatException)
            {
                throw new FormatException($"The format of the prodcut ID {transactionDetails[productIDPlacementTransaction]} is invalid");
            }
            catch (ElementDoesNotExistException)
            {
                throw;
            }
            try
            {
                //The date of the transaction
                transactiondate = StringToDateTime(transactionDetails[datePlacementTransaction]);
            }
            catch
            {
                throw new FormatException($"The transactiondate {transactionDetails[datePlacementTransaction]} is not valid");
            }
            try
            {
                //The fourth is the price
                price = decimal.Parse(transactionDetails[amountOfMoneyPlacementTransaction]);
            }
            catch
            {
                throw new FormatException($"The string {transactionDetails[amountOfMoneyPlacementTransaction]} is not a valid decimal number, and can therefore not represent a price");
            }
            try
            {
                //The fifth is the discount amount
                discountAmount = decimal.Parse(transactionDetails[discountAmountPlacementTransaction]);
            }
            catch
            {
                throw new FormatException($"The string {transactionDetails[discountAmountPlacementTransaction]} is not a valid decimal, and can not represent the discount amount");
            }
            try
            {
                //The sixth one is the amount of products bought in this transaction
                amountOfProducts = int.Parse(transactionDetails[amountOfProductsBoughtPlacementTransaction]);
            }
            catch
            {
                throw new FormatException($"The string {transactionDetails[amountOfProductsBoughtPlacementTransaction]} is not a valid int, and can not be an amount of products");
            }
            try
            {
                //The name of the product in case something should go wrong with the ID system
                nameOfProduct = transactionDetails[productNamePlacementTransaction];
                //The optional comment when purchace is made
                comment = transactionDetails[commentPlacementTransaction];
            }
            catch
            {
                throw new FormatException("This would make no scense, but it is with the comment it is wrong");
            }
            try
            {
                //Here I add the transaction to the list
                listOfTransactions.Add(new BuyTransaction(price, product, discountAmount, transactionID, transactiondate, amountOfProducts, comment, nameOfProduct));
            }
            catch
            {
                throw new FormatException("The product was not possible to make");
            }
        }
        #endregion

        #region Tools
        /// <summary>
        /// Convert a sting in format DD/MT/YYYY HH:MM:SS to datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        //TODO Better warnings
        //TODO Bette security 
        public static DateTime StringToDateTime(string dateTime)
        {
            try
            {
                //Separate the date from the time
                string[] separated = dateTime.Split(' ');
                //The first entrance is a date
                string[] date = separated[0].Split('/');
                //The second entrance is the time
                string[] time = separated[1].Split(':');

                //This is to test if the format is right. 
                string year = date[2];
                string month = date[1];
                string day = date[0];

                string hour = time[0];
                string minute = time[1];
                string second = time[2];

                //See if the format is right
                if (!(year.Length == 4 && month.Length == 2 && day.Length == 2 && hour.Length == 2 && minute.Length == 2 && second.Length == 2))
                {
                    throw new FormatException();
                }
                
                //Because of the order things are in, i have had to move around. 
                //                      The year            The Month           The day             The hour            The minute            The second  
                return new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            }
            //Everything that does so this does not work, is a wrong format. Therefore I will throw a format exception
            catch (Exception)
            {
                throw new FormatException(dateTime + " StringToDateTime");
            }
        }
        #endregion
    }
}