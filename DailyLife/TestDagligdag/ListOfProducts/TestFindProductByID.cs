using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;

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
            ListOfProducts productlist = new ListOfProducts();

            productlist.AddProductFromStartup("Mælk", UnitType.l, ProductType.Food, 1);
            productlist.AddProductFromStartup("Kage", UnitType.kg, ProductType.Snack,2);

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
            ListOfProducts productlist = new ListOfProducts();

            productlist.AddProductFromStartup("Mælk", UnitType.l, ProductType.Food, 1);
            productlist.AddProductFromStartup("Kage", UnitType.kg, ProductType.Snack, 2);

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
            ListOfProducts productlist = new ListOfProducts();

            productlist.AddProductFromStartup("Mælk", UnitType.l, ProductType.Food, 1);
            productlist.AddProductFromStartup("Kage", UnitType.kg, ProductType.Snack,2);

            Assert.AreEqual(productlist.FindProductByID(1).PrimaryProductName, "Mælk");
        }
    }

}
