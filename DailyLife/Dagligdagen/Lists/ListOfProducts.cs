using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public class ListOfProducts : ListType, IEnumerable<Product>
    {
        #region constructors
        /// <summary>
        /// Makes it possible to add a list of products as a startup. 
        /// </summary>
        /// <param name="primaryProductName"></param>
        /// <param name="typeOfUnit"></param>
        /// <param name="productType"></param>
        public ListOfProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                //So there is a unique iD
                foreach (Product productInAlreadyMadeList in this.listOfProducts)
                {
                    if (productInAlreadyMadeList.ID == product.ID)
                    {
                        throw new IDAlreadyTakenException($"The product ID {iD} is already taken");
                    }
                }
                listOfProducts.Add(product);

                if (product.ID >= this.iD)
                {
                    this.iD = iD + 1;
                }
            }
        }
        /// <summary>
        /// Makes it possible to make a new list without neding 
        /// </summary>
        public ListOfProducts()
        {

        }
        #endregion

        #region Fields and proporties 
        /// <summary>
        /// The list containing all the products
        /// </summary>
        private List<Product> listOfProducts = new List<Product>();
        #endregion

        #region Info
        //Send back a readonly list
        public IEnumerable<Product>  ProductList
        {
            get { return listOfProducts; }
        }
        /// <summary>
        /// Resturns the number of products in the list of products
        /// </summary>
        public int NumberOfProducts
        {
            get { return listOfProducts.Count(); }
        }
        #endregion

        #region Change list
        /// <summary>
        /// Add new product on the list
        /// </summary>
        /// <param name="primaryProductName"></param>
        /// <param name="typeOfUnit"></param>
        /// <param name="productType"></param>
        public void AddProduct(string primaryProductName, UnitType typeOfUnit, ProductType productType)
        {
            listOfProducts.Add(new Product(iD, primaryProductName, typeOfUnit, productType));
            iD++;
        }
        #endregion

        #region Seach
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
        #endregion

        #region Ienumerable
        public IEnumerator<Product> GetEnumerator()
        {
            return listOfProducts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listOfProducts.GetEnumerator();
        }
        #endregion


    }
}
