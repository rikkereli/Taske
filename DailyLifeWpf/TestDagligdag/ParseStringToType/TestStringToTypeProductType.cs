using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;

namespace TestDagligdag
{
    [TestClass]
    public class TestStringToTypeProductType
    {
        /// <summary>
        /// Test if the string Food returns the right type
        /// </summary>
        [TestMethod]
        public void TestStringToFood()
        {
            ProductType productType;
            productType = ParseStringToType.ProductType("Food");

            Assert.AreEqual(productType, ProductType.Food);
        }
        /// <summary>
        /// Test if the string Snack returns the right type
        /// </summary>
        [TestMethod]
        public void TestStringToSnack()
        {
            ProductType productType;
            productType = ParseStringToType.ProductType("Snack");

            Assert.AreEqual(productType, ProductType.Snack);
        }
        /// <summary>
        /// Test if the string Fun returns the right type
        /// </summary>
        [TestMethod]
        public void TestStringToFun()
        {
            ProductType productType;
            productType = ParseStringToType.ProductType("Fun");

            Assert.AreEqual(productType, ProductType.Fun);
        }
        /// <summary>
        /// Test if the string Household returns the right type
        /// </summary>
        [TestMethod]
        public void TestStringToHousehold()
        {
            ProductType productType;
            productType = ParseStringToType.ProductType("Household");

            Assert.AreEqual(productType, ProductType.Household);
        }
        /// <summary>
        /// Test if invalid string returns the right type
        /// </summary>
        [TestMethod]
        public void TestStringNotFound()
        {
            ProductType productType;
            productType = ParseStringToType.ProductType("Foods");

            Assert.AreEqual(productType, ProductType.NotFound);
        }
    }
}
