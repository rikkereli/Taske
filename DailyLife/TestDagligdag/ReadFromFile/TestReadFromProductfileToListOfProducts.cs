using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Dagligdagen;
using System.Collections.Generic;

namespace TestDagligdag
{
    [TestClass]
    public class TestReadFromProductfileToListOfProducts
    {
        #region Filepaths
        //Make reuable pile paths that cannot be changed
        private readonly string productValidWithTwoProductFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Products\\TestProductsWithTwoProductsIsRight.txt",
                                productlistWithOneUnvalidProduct = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Products\\TestProductsWithTwoProductsMissingACategory.txt",
                                //Is a standard discard product file for when you don't have to use the information for anything 
                                standardDiscardProductFile = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\WriteToProducts\\StandardDiscardProductFile.txt",
                                seeIfRightStringIsDiscarded = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\WriteToProducts\\SeeIfTheRightStringIsDiscarded.txt";
        #endregion

        /// <summary>
        /// Test if a file is read with expected number of products
        /// </summary>
        [TestMethod]
        public void TestIfFileIsRead()
        {
            System.IO.File.WriteAllText(standardDiscardProductFile, string.Empty);
            List<Product> products = ReadFromFiles.ReadFromProductfileToListOfProducts(productValidWithTwoProductFilePath, standardDiscardProductFile);
            
            Assert.IsTrue(products.Count == 2);
        }
        /// <summary>
        /// Test if products are discarded when wrong number of categories 
        /// </summary>
        [TestMethod]
        public void TestIfProductsAreNotAddedWhenWrongAmountOfCategories() 
        {
           List<Product> products = new List<Product>();


                System.IO.File.WriteAllText(standardDiscardProductFile, string.Empty);
                products = ReadFromFiles.ReadFromProductfileToListOfProducts(productlistWithOneUnvalidProduct, standardDiscardProductFile);

            Assert.IsTrue(products.Count == 1);
        }
        /// <summary>
        /// Test if the right product is discarded when wrong number of categories 
        /// </summary>
        [TestMethod] 
        public void TestIfRightProductIsDiscarded()
        {
            List<Product> products = new List<Product>();

            System.IO.File.WriteAllText(seeIfRightStringIsDiscarded, string.Empty);
            products = ReadFromFiles.ReadFromProductfileToListOfProducts(productlistWithOneUnvalidProduct,seeIfRightStringIsDiscarded);

            Assert.IsTrue(System.IO.File.ReadAllText(seeIfRightStringIsDiscarded) == "2;Mælk;Food");
        }

    }
}
