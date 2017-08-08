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

        #region InformationPlacements

        #region Transaction
        // The placements of the information in the transaction files, as it would be in an array. Makes it more flexible
        //TODO maybe lock values
        private static int transactionTypePlacementTransaction = 0,
                           transactioniDPlacementTransaction = 1,
                           productIDPlacementTransaction = 2,
                           datePlacementTransaction = 3,
                           amountOfMoneyPlacementTransaction = 4,
                           productNamePlacementTransaction = 5,
                           commentPlacementTransaction = 6,
                           discountAmountPlacementTransaction = 7,
                           amountOfProductsBoughtPlacementTransaction = 8;
        #endregion
        #region Products
        //The placement for the information about products
        private static int productIDPlacement = 0,
                           primaryProductNamePlacement = 1,
                           productTypePlacement = 2,
                           productUnitTypePlacement = 3,

                           productDetailsCount = 4;
        #endregion
        #endregion

        #region ProductFiles
        /// <summary>
        /// Takes the file with products and read it in to a list of products to use at runtime
        /// </summary>
        /// <returns></returns>
        public static List<Product> ReadFromProductfileToListOfProducts(string path, string writeToPath)
        {
            //The list of products to be returned
            List<Product> products = new List<Product>();

            //The file we write to if the product line is invalid
            System.IO.StreamWriter discardFile = new System.IO.StreamWriter(writeToPath, true);

            //Makes a string array of all the lines in the file with products
            string[] productLines = System.IO.File.ReadAllLines(path);

            //Makes sure the first line with the info is not read
            bool firstIsDone = false;

            foreach (string line in productLines)
            {
                if (firstIsDone)
                {
                    MakeProductsFromFile(products, line,discardFile);
                }
                else
                {
                    firstIsDone = true;
                }
            }
            discardFile.Close();

            return products;
        }
        /// <summary>
        /// Makes a product from list of products in file. Returns a string with explanation if the product is invlid
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static void MakeProductsFromFile(List<Product> products, string line, System.IO.StreamWriter discardFile)
        {
            #region Variables
            //The string that explains what is wrong with the product
            string explantion = null;
            string[] productDetails = line.Split(';');
            //The product ID
            uint ID = 0;
            //The primary productname
            string name = "";
            //TODO make better standard for this
            //The product type
            ProductType productType = ProductType.Food;
            //The type of unit you messure the product with
            UnitType unitType = UnitType.piece;
            #endregion

            #region Make Product

            if (productDetails.Length == productDetailsCount)
            {
                #region ID
                try
                {
                    ID = uint.Parse(productDetails[productIDPlacement]);
                }
                catch
                {
                    explantion += $"ID: The product ID {productDetails[productIDPlacement]} cannot be parsed to a uint, and is therefore invalid. ";

                }
                #endregion
                name = productDetails[primaryProductNamePlacement];
                #region Find producttype
                //Find the relevant producttype
                productType = ParseStringToType.ProductType(productDetails[productTypePlacement]);

                //Makes sure there is an error when producttype not found
                if (productType == ProductType.NotFound)
                {
                    explantion += $"ProductType: The string {productDetails[productTypePlacement]} is not a valid type. ";
                }
                #endregion
                #region Make unit type
                //Find the propor unit type
                unitType = ParseStringToType.UnitType(productDetails[productUnitTypePlacement]);

                if (unitType == UnitType.notFound)
                {
                    explantion += $"The string {productDetails[productUnitTypePlacement]} is not a valid unittype. ";
                }
                #endregion
            }
            else
            {
                explantion += $"Length: The number of informations is {productDetails.Length}, it should be {productDetailsCount}";
            }
            if (explantion == null)
            {
                products.Add(new Product(ID, name, unitType, productType));
            }
            else
            {
                discardFile.WriteLine($"{line};{explantion}");
            }
        }
            #endregion
        
        #endregion

        #region TransactionFiles
        /// <summary>
        /// Takes the file with transactions and reads them in to a list of transactions to use at runtime
        /// </summary>
        /// <returns></returns>
        public static List<Transaction> ReadFromTransactionFileToListOfTransactions(string path, ListOfProducts listOfProducts, string DiscardedFile)
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

            return listOfTransactions;
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
                transactionID = UInt32.Parse(transactionDetails[transactioniDPlacementTransaction]);
            }
            catch (FormatException)
            {
                throw new FormatException($"The format of the transactionID {transactionDetails[transactioniDPlacementTransaction]} is invalid. ");
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
                transactiondate = ParseStringToType.StringToDateTime(transactionDetails[datePlacementTransaction]);
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


    }
}