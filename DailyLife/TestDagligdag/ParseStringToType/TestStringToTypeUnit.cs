using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;

namespace TestDagligdag
{
    /// <summary>
    /// Test the method UnitType in ParseStringToType
    /// </summary>
    [TestClass]
    public class TestStringToTypeUnit
    {
        #region succes
        /// <summary>
        /// Test if the l is right
        /// </summary>
        [TestMethod]
        public void TestRightWhenl()
        {
            UnitType type = ParseStringToType.UnitType("l");

            Assert.AreEqual(type, UnitType.l);
        }
        /// <summary>
        /// Test if the kg is right
        /// </summary>
        [TestMethod]
        public void TestRightWhenkg()
        {
            UnitType type = ParseStringToType.UnitType("kg");

            Assert.AreEqual(type, UnitType.kg);
        }
        /// <summary>
        /// Test if the KG is right
        /// </summary>
        [TestMethod]
        public void TestRightWhenKg()
        {
            UnitType type = ParseStringToType.UnitType("Kg");

            Assert.AreEqual(type, UnitType.kg);
        }
        /// <summary>
        /// Test if the g is right
        /// </summary>
        [TestMethod]
        public void TestRightWheng()
        {
            UnitType type = ParseStringToType.UnitType("g");

            Assert.AreEqual(type, UnitType.g);
        }
        /// <summary>
        /// Test if the piece is right
        /// </summary>
        [TestMethod]
        public void TestRightWhenPiece()
        {
            UnitType type = ParseStringToType.UnitType("piece");

            Assert.AreEqual(type, UnitType.piece);
        }
        /// <summary>
        /// Test if it returns not found
        /// </summary>
        [TestMethod]
        public void TestNotFound()
        {
            UnitType type = ParseStringToType.UnitType("Ll");

            Assert.AreEqual(type, UnitType.notFound);
        }
        #endregion
    }
}
