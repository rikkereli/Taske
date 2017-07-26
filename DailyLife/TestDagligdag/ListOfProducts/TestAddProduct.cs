using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;

namespace TestDagligdag
{
    /// <summary>
    /// Test the AddProduct method in ListOfProducts
    /// </summary>
    [TestClass]
    public class TestAddProduct
    {
        /// <summary>
        /// See if the start number of elements on the list is zero
        /// </summary>
        [TestMethod]
        public void SeeIfStartProductCountIsZero()
        {
            ListOfProducts productList = new ListOfProducts();
            Assert.AreEqual(productList.NumberOfProducts, 0);
        }
        /// <summary>
        /// See if the number of elements in the list is changed when one element is added
        /// </summary>
        [TestMethod]
        public void SeeIfProductIsAdded()
        {
            ListOfProducts productList = new ListOfProducts();
            productList.AddProduct("Mælk", UnitType.l, ProductType.Snack);
            Assert.AreEqual(productList.NumberOfProducts, 1);
        }
    }
}
