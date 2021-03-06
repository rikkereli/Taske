﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;
using System.IO;
using System.Collections.Generic;

namespace TestDagligdag
{
    /// <summary>
    /// Test if the read from file of transactions works
    /// </summary>
    [TestClass]
    public class TestReadFromTransactions
    {
        private readonly string validTransactionFileWithTwoTransactions = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Transactions\\TestTransactionsTwoWithTwoIsRight.txt";

        /// <summary>
        /// See if the file is even read
        /// </summary>
        [TestMethod]
        public void TestIfFileIsRead()
        {
            string[] fileText = System.IO.File.ReadAllLines(validTransactionFileWithTwoTransactions);
            Assert.AreEqual(fileText.Length, 3);
        }
        /// <summary>
        /// Test if all transactions is read
        /// </summary>
        [TestMethod]
        public void TestIfRightAmountOfLines()
        {
            List<Product> products = new List<Product>() { new Product(1,"Mælk","l", "Food"), new Product(2,"Kage", "kg", "Snack")};
            ListOfProducts listOfProducts = new ListOfProducts(products,null);
            ListOfTransactions transactions =  new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(validTransactionFileWithTwoTransactions, listOfProducts, null),null);
            Assert.AreEqual(transactions.NumberOfTransactions, 2);
        }
        /// <summary>
        /// Test if all transactions is read
        /// </summary>
        [TestMethod]
        public void TestIfRightTransactionsIsMade()
        {
            List<Product> products = new List<Product>() { new Product(1, "Mælk", "l", "Food"), new Product(2, "Kage", "kg", "Snack") };
            ListOfProducts listOfProducts = new ListOfProducts(products,null);

            ListOfTransactions transactions = new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(validTransactionFileWithTwoTransactions, listOfProducts, null),null);
            Assert.AreEqual(transactions.FindTransactionByID(1).AmountOfMoney, 10);
        }
    }

}
