using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class ListOfProducts : List
    {
        /// <summary>
        /// The list containing all the products
        /// </summary>
        private List<Product> listOfProducts = new List<Product>();

        public void AddProduct(string primaryProductName, UnitType typeOfUnit, ProductType productType)
        {
            listOfProducts.Add(new Product(iD, primaryProductName, typeOfUnit, productType));
        }
        public Product FindProductByID(uint ID)
        {
            foreach (Product product in listOfProducts)
            {
                if (ID == product.ID)
                {
                    //returns the product with the correct ID
                    return product;
                }
            }
            //If no product is found
            return null;
        }


    }
}
