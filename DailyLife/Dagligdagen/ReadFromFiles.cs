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
        /// <summary>
        /// Takes the file with products and read it in to a list of products to use at runtime
        /// </summary>
        /// <returns></returns>
        public static ListOfProducts ReadFromProductfileToListOfProducts() { return null; }
        /// <summary>
        /// Takes the file with transactions and reads them in to a list of transactions to use at runtime
        /// </summary>
        /// <returns></returns>
        public static ListOfTransactions ReadFromTransactionFileToListOfTransactions(string path, ListOfProducts products)
        {
            //The list to be returned
            ListOfTransactions transactions = new ListOfTransactions();
            //The number of informationslots in te list
            int numberOfInformationslots = 7;
            //Read the text from the files into an array of strings, so every transaction has a entrance
            string[] lines = System.IO.File.ReadAllLines(path);
            //Makes sure the first describing line is not translated.
            bool firstIsDone = false;
            foreach (string line in lines)
            {
                //TODO better security
                if (firstIsDone)
                {
                    string[] transactionDetails = line.Split(';');
                    if (transactionDetails.Length == numberOfInformationslots)
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

                        try
                        {
                            //The first enterance contains the ID
                            transactionID = UInt32.Parse(transactionDetails[0]);
                            //The second contains the ID. This will be used to find the product
                            uint productID = UInt32.Parse(transactionDetails[1]);
                            product = products.FindProductByID(productID);
                            //The third contains the date
                            transactiondate = StringToDateTime(transactionDetails[2]);
                            //The fourth is the price
                            price = decimal.Parse(transactionDetails[3]);
                            //The fifth is the discount amount
                            discountAmount = decimal.Parse(transactionDetails[4]);
                            //The sixth one is the amount of products bought in this transaction
                            amountOfProducts = int.Parse(transactionDetails[5]);
                            //The last one is an voluntary comment
                            comment = transactionDetails[5];

                            //Here I add the transaction to the list
                            transactions.AddBuyTransaction(price, product, discountAmount, transactiondate, amountOfProducts, comment);
                        }
                        catch
                        {
                            //TODO implement exception handeling 
                        }
                    }
                    else
                    {
                        //Makes sure the line is added to a list of broken transactions
                        throw new FormatException($"The number of segments in the line is wrong. It should be {numberOfInformationslots} but it is {transactionDetails.Length} \n The line is {line}");
                    }
                }
                else
                {
                    //Shows that the first is done, so the code will go into the if statement.
                    firstIsDone = true;
                }
            }

            return transactions;
        }
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
    }
}