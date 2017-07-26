using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;
using System.IO;

namespace TestDagligdag
{
    /// <summary>
    /// Test if the read from file of transactions works
    /// </summary>
    [TestClass]
    public class TestReadFromTransactions
    {
        private string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\TestTransactions.txt";
        /// <summary>
        /// See if the file is even read
        /// </summary>
        [TestMethod]
        public void TestIfFileIsRead()
        {
            string[] fileText = System.IO.File.ReadAllLines(transactionFilePath);
            Assert.AreEqual(fileText.Length, 3);
        }
        /// <summary>
        /// Test if all transactions is read
        /// </summary>
        [TestMethod]
        public void TestIfRightAmountOfLines()
        {
            ListOfProducts listOfProducts = new ListOfProducts();
            listOfProducts.AddProduct("Mælk", UnitType.l, ProductType.Food);
            listOfProducts.AddProduct("Kage", UnitType.kg, ProductType.Snack);
            ListOfTransactions transactions = ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, listOfProducts);
            Assert.AreEqual(transactions.NumberOfTransactions, 2);
        }
        /// <summary>
        /// Test if all transactions is read
        /// </summary>
        [TestMethod]
        public void TestIfRightTransactionsIsMade()
        {
            ListOfProducts listOfProducts = new ListOfProducts();
            listOfProducts.AddProduct("Maelk", UnitType.l, ProductType.Food);
            listOfProducts.AddProduct("Kage", UnitType.kg, ProductType.Snack);
            ListOfTransactions transactions = ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, listOfProducts);
            Assert.AreEqual(transactions.FindTransactionByID(1).Product.ID, 2);
        }
    }

}
