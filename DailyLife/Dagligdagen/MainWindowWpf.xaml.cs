using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dagligdagen;
using System.IO;

namespace Dagligdagen
{
    /// <summary>
    /// Interaction logic for MainWindowWpf.xaml
    /// </summary>
    public partial class MainWindowWpf : Window, System.Windows.Markup.IComponentConnector
    {
        #region Fields 
        private ListOfProducts productList;
        private ListOfTransactions transactionList;

        #endregion

        public MainWindowWpf()
        {
            InitializeComponent();
            string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\Transactions.txt";
            string productFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\Products.txt";
            string discardedTransactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\DiscardedTransactions.txt";
            string discardedProductFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\DiscardedProducts.txt";

            productList = new ListOfProducts(ReadFromFiles.ReadFromProductfileToListOfProducts(productFilePath, discardedProductFilePath), productFilePath);
            transactionList = new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, productList, discardedTransactionFilePath), transactionFilePath);

            //Make the buttons in the product combobox
            foreach (Product product in productList.ProductList)
            {
                /*
                Button b = new Button();
                b.Content = product.PrimaryProductName;
                b.TabIndex = (int)product.ID + 3;
                ProductCombobox.Items.Add(b);
                */
                ProductCombobox.Items.Add(product);
            }

        }

        //The fields in the make transaction
        #region MakeTransaction

        private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PriceTX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DiscountAmountTX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// Add a new transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                decimal price = decimal.Parse(PriceTX.Text);
                Product product = (Product)ProductCombobox.SelectionBoxItem;
                int amount = int.Parse(AmountTX.Text);
                decimal discountAmount = decimal.Parse(DiscountAmountTX.Text);
                ProductType productType = ParseStringToType.ProductType(TypeCombobox.Text);
                DateTime dateTime = (DateTime)DateTimePicker.Value;
                String comment = CommentTX.Text;
                transactionList.AddBuyTransaction(price, product, discountAmount, dateTime, amount, comment, product.PrimaryProductName);
                CommentTX.Text = transactionList.LatestAdded.ToString();
            }
            catch
            {
                CommentTX.Text = "Something went wrong";
            }


        }
        #endregion

        //The fields in the main menu
        #region Menu
        private void SeeTransactions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MakeProduct_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Show and hide the make transaction window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeTransaction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void See_products_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Make the transaction window show and hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMakeProduct_Click(object sender, RoutedEventArgs e)
        {
            if (AddProductToTransaction.Visibility == Visibility.Hidden)
            {
                AddProductToTransaction.Visibility = Visibility.Visible;
            }
            else
            {
                AddProductToTransaction.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// When you click on the button to make a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Make_Click(object sender, RoutedEventArgs e)
        {
            productList.AddProduct(ProductName.Text, ParseStringToType.UnitType(UnitType.Text), ParseStringToType.ProductType(ProductType.Text));
            ProductName.Text = productList.LastAdded.ToString();
            Make_product.Visibility = Visibility.Hidden;
        }
    }
}

