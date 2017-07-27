using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;
using System.Collections.Generic;

namespace TestDagligdag
{
    /// <summary>
    /// See if the method FindProductByID in ListOfProducts works
    /// </summary>
    [TestClass]
    public class TestFindProductByID
    {
        /// <summary>
        /// See if the product that is returned back is the right product by name
        /// </summary>
        [TestMethod]
        public void SeeIfProductByIDWorksByName()
        {
            List<Product> products = new List<Product>() { new Product(1, "Mælk", UnitType.l, ProductType.Food), new Product(2, "Kage", UnitType.kg, ProductType.Snack) };

            ListOfProducts productlist = new ListOfProducts(products);

            Product foundProduct = productlist.FindProductByID(1);
            //See if the product found is the same as the expected
            Assert.IsTrue(foundProduct.PrimaryProductName == "Mælk");
        }

        /// <summary>
        /// See if the product that is returned back is the right product by Product type
        /// </summary>
        [TestMethod]
        public void SeeIfProductByIDWorksByProductType()
        {
            List<Product> products = new List<Product>() { new Product(1, "Mælk", UnitType.l, ProductType.Food), new Product(2, "Kage", UnitType.kg, ProductType.Snack) };

            ListOfProducts productlist = new ListOfProducts(products);

            Product foundProduct = productlist.FindProductByID(1);
            //See if the product found is the same as the expected
            Assert.IsTrue(foundProduct.TypeOfProduct == ProductType.Food);
        }
        /// <summary>
        /// Find product by ID should return null if product does not exist
        /// </summary>
        [TestMethod]
        public void SeeIfProductByIDReturnsNullIfProductDoesNotExist()
        {
            List<Product> products = new List<Product>() { new Product(1, "Mælk", UnitType.l, ProductType.Food), new Product(2, "Kage", UnitType.kg, ProductType.Snack) };
            ListOfProducts productlist = new ListOfProducts(products);

            Assert.AreEqual(productlist.FindProductByID(1).PrimaryProductName, "Mælk");
        }
    }

}
