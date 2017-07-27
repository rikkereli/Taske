using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dagligdagen;

namespace TestDagligdag
{
    /// <summary>
    /// Test the StringToDate method in ReadFromFiles
    /// </summary>
    [TestClass]
    public class TestStringToDate
    {
        /// <summary>
        /// Test if we get the right output with the right format
        /// </summary>
        [TestMethod]
        public void TestWhenFormatIsRight()
        {
            //The date to parse
            string dateTime = "25/07/2017 12:47:00";

            Assert.IsTrue(ReadFromFiles.StringToDateTime(dateTime).ToString() == dateTime);
        }
        /// <summary>
        /// Test if it works flexible, always using now.
        /// </summary>
        [TestMethod]
        public void TestWithDatetimeNow()
        {
            //Find now
            string dateTimeNow = DateTime.Now.ToString();

            Assert.IsTrue(ReadFromFiles.StringToDateTime(dateTimeNow).ToString() == dateTimeNow);
        }
        /// <summary>
        /// Test if we get a formatexception when the yearformat is wrong
        /// </summary>
        [TestMethod]
        public void TestWhenYearformatIsWrong()
        {
            //Becomes true if the right exception is cast
            bool formatExceptionIsCast = false;
            string wrongYearFormat = "25/07/17 12:30:05";
            try
            {
                Console.WriteLine(ReadFromFiles.StringToDateTime(wrongYearFormat));
                Console.ReadKey();
            }
            catch (FormatException)
            {
                formatExceptionIsCast = true;
            }
            catch (Exception)
            {
            }
            Assert.AreEqual(formatExceptionIsCast, true);
        }
        /// <summary>
        /// Test when the month is invalid
        /// </summary>
        [TestMethod]
        public void TestWhenInvalidMonth()
        {
            //Be sure the right exception is cast
            bool exceptionIsCast = false;
            string dateTime = "25/17/2017 12:47:00";
            try
            {
                Console.WriteLine(ReadFromFiles.StringToDateTime(dateTime));
                Console.ReadKey();
            }
            catch (FormatException)
            {
                exceptionIsCast = true;
            }
            catch (Exception)
            {
            }
            Assert.AreEqual(exceptionIsCast, true);
        }
        /// <summary>
        /// Test when component is negative
        /// </summary>
        [TestMethod]
        public void TestWhenComponentIsNegative()
        {
            //Be sure the right exception is cast
            bool exceptionIsCast = false;
            string dateTime = "-5/07/2017 12:47:00";
            try
            {
                Console.WriteLine(ReadFromFiles.StringToDateTime(dateTime));
                Console.ReadKey();
            }
            catch (FormatException)
            {
                exceptionIsCast = true;
            }
            catch (Exception)
            {
            }
            Assert.AreEqual(exceptionIsCast, true);
        }
        /// <summary>
        /// Test when wrong separators
        /// </summary>
        [TestMethod]
        public void TestWhenWrongSeparators()
        {
            //Be sure the right exception is cast
            bool exceptionIsCast = false;
            string dateTime = "22:22/2222 22:22:22";
            try
            {
                Console.WriteLine(ReadFromFiles.StringToDateTime(dateTime));
                Console.ReadKey();
            }
            catch (FormatException)
            {
                exceptionIsCast = true;
            }
            catch (Exception)
            {
            }
            Assert.AreEqual(exceptionIsCast, true);
        }
    }

}
