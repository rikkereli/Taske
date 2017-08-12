using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dagligdagen
{
    /// <summary>
    /// The products possible
    /// </summary>
    public class Product
    {
        #region Constructor
        public Product(int iD, string primaryProductName, string typeOfunit, string productType)
        {
            this.iD = iD;
            PrimaryProductName = primaryProductName;
            this.typeOfunit = typeOfunit;
            this.productType = productType;
        }
        #endregion

        #region Proporties

        #region ProductType
        private string productType;
        /// <summary>
        /// The product's type
        /// </summary>
        public string TypeOfProduct
        {
            get { return productType; }
        }
        #endregion

        #region UnitType
        private string typeOfunit;
        /// <summary>
        /// The default type the product is messured in
        /// </summary>
        public string TypeOfUnit
        {
            get { return TypeOfUnit; }
        }
        #endregion

        #region ID
        private int iD;
        /// <int>
        /// The unique ID for this product.
        /// </summary>
        /// To make sure the product ID is not changed after initialization. 
        public int ID
        {
            get { return iD; }
        }
        #endregion

        #region ProductNames
        /// <summary>
        /// Because a product can have sevral names 
        /// </summary>
        private List<string> productNames;
        /// <summary>
        /// Add a productname to the list of names for specific product
        /// </summary>
        /// <param name="name"></param>
        public void AddProductname(string name)
        {
            if (name != null)
            {
                productNames.Add(name);
            }
            else
            {
                throw new ArgumentNullException("A productname can't be null. AddProductName");
            }
        }
        private string primaryProductName;
        /// <summary>
        /// The name primarily used for the product
        /// </summary>
        public string PrimaryProductName
        {
            get { return primaryProductName; }
            set
            {
                if (value != null)
                {
                    primaryProductName = value;
                }
            }
        }
        #endregion
        //TODO add a describtion
        #endregion

        #region String
        public static string TableExplanation()
        {
            return $"ID | Product name | Product type";
        }
        /// <summary>
        /// The format the class writes out the product with when used for a table
        /// </summary>
        /// <returns></returns>
        public string TableFormat()
        {
            return $"{iD} | {primaryProductName} | {productType}";
        }
        public override string ToString()
        {
            return primaryProductName;   
        }
        /// <summary>
        /// The format the product is to be written with in the file
        /// </summary>
        /// <returns></returns>
        public string FileFormat()
        {
            return $"{ID};{PrimaryProductName};{productType};{typeOfunit}";
        }
        #endregion
    }
}