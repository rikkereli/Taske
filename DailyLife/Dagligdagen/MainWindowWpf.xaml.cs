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
using Xceed.Wpf.Toolkit;
using System.Data;
using System.Data.SQLite;

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

        private SQLiteConnection sqlite = new SQLiteConnection("Data Source=C:/Users/Rikke/Documents/GitHub/Taske/DailyLife/Database/MyDatabase.db");
        #endregion

        public MainWindowWpf()
        {

            InitializeComponent();
            DataTable TableWithProducts = InteractWithDatabase.SelectQuery("Select * From Products", sqlite);
            productList = new ListOfProducts(InteractWithDatabase.ProductTableToListOfProducts(TableWithProducts), sqlite);
            transactionList = new ListOfTransactions(null);

            //Make the buttons in the product combobox
            foreach (Product product in productList.ProductList)
            {
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
                transactionList.AddBuyTransaction(price, product, discountAmount, dateTime, amount, comment, product.PrimaryProductName, 0, 0);
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
            //TODO make check if productname exists
            string productName = ProductNameTB.Text;
            bool productNameEmpty = productName == "";
            string unittype = UnitType.Text;
            //Check if unittype is found
            string productType = ProductType.Text;

            //Writes the problem out to the user
            if (productNameEmpty)
            {
                Error_field.Text = "";

                Error_field.Text += "Productname can't be empty\n";

                Product_is_not_valid.Show();
            }
            else
            {
                productList.AddProduct(productName, unittype, productType);
                ProductCombobox.Items.Add(productList.LastAdded);
                Make_product.Close();
            }
        }
        /// <summary>
        /// Opens the add product from menu site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeProductMenu(object sender, RoutedEventArgs e)
        {
            Make_product.Show();
        }
        /// <summary>
        /// Opens the add product from transaction site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductFromTransaction(object sender, RoutedEventArgs e)
        {
            Make_product.Show();
        }
    }
}

