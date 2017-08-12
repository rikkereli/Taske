using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Dagligdagen
{
    public static class InteractWithDatabase
    {

        /// <summary>
        /// Read from the database table containing products to list of products
        /// </summary>
        /// <returns></returns>
        public static List<Product> ProductTableToListOfProducts(DataTable table)
        {
            //The list that is going to be returned containing all the products in the table
            List<Product> resultList = new List<Product>();

            //Adds the product to the list of product
            foreach (DataRow row in table.Rows)
            {
                resultList.Add(new Product(int.Parse(row["ProductID"].ToString()), row["ProductName"].ToString(), row["UnitType"].ToString(), row["TypeOfProduct"].ToString()));
            }

            return resultList;
        }

        /// <summary>
        /// Interact with table by command
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlite"></param>
        /// <returns></returns>
        public static DataTable SelectQuery(string query, SQLiteConnection sqlite)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                sqlite.Open();  //Initiate connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                //Add your exception code here.
            }
            sqlite.Close();
            return dt;
        }
    }
}
