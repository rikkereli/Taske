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
        private ProductType productType;
        /// <summary>
        /// The product's type
        /// </summary>
        public ProductType TypeOfProduct
        {
            get { return productType; }
        }
        private UnitType typeOfunit;
        /// <summary>
        /// The default type the product is messured in
        /// </summary>
        public UnitType TypeOfUnit
        {
            get { return TypeOfUnit; }
        }
        public Product(uint iD, string primaryProductName, UnitType typeOfunit, ProductType productType)
        {
            this.iD = iD;
            PrimaryProductName = primaryProductName;
            this.typeOfunit = typeOfunit;
            this.productType = productType;
        }
        private uint iD;
        /// <summary>
        /// The unique ID for this product.
        /// </summary>
        /// To make sure the product ID is not changed after initialization. 
        public uint ID
        {
            get { return iD; }
        }
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
    }
}