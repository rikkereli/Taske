using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    class ListOfProducts : List
    {
        /// <summary>
        /// The list containing all the products
        /// </summary>
        private List<Product> listOfProducts = new List<Product>();

        public void addProduct(string primaryProductName, UnitType typeOfUnit, ProductType productType)
        {
            listOfProducts.Add(new Product(iD, primaryProductName, typeOfUnit, productType));
        }
        
    }
}
