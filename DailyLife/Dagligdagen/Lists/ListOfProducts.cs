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
        //Send back a readonly list
        public IEnumerable<Product>  ProductList
        {
            get { return listOfProducts; }
        }
        /// <summary>
        /// Make the product so it has it's original ID
        /// </summary>
        /// <param name="primaryProductName"></param>
        /// <param name="typeOfUnit"></param>
        /// <param name="productType"></param>
        public void AddProductFromStartup(string primaryProductName, UnitType typeOfUnit, ProductType productType, uint iD)
        {
            //So there is an unique iD
            foreach (Product product in listOfProducts)
            {
                if (product.ID == iD)
                {
                    throw new IDAlreadyTakenException($"The product ID {iD} is already taken");
                }
            }
            listOfProducts.Add(new Product(iD, primaryProductName, typeOfUnit, productType));

            if (iD >= this.iD)
            {
                this.iD = iD + 1;
            }
        }
        /// <summary>
        /// Add new product on the list
        /// </summary>
        /// <param name="primaryProductName"></param>
        /// <param name="typeOfUnit"></param>
        /// <param name="productType"></param>
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
        /// <summary>
        /// TODO implement this proporly. Make sure you seach on both primary name and name synonymes
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product FindProductByName(string name)
        {
            foreach (Product product in listOfProducts)
            {
                if (name == product.PrimaryProductName)
                {
                    //returns the product with the correct ID
                    return product;
                }
            }
            //If no product is found
            return null;
        }
        /// <summary>
        /// Resturns the number of products in the list of products
        /// </summary>
        public int NumberOfProducts
        {
            get { return listOfProducts.Count(); }
        }
    }
}
