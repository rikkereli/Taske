using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Threading.Tasks;

namespace sqLite3Test
{
    public class Class1
    {
        private SQLiteConnection sqlite;

        public Class1()
        {
            sqlite = new SQLiteConnection("Data Source=C:/Users/Rikke/Documents/GitHub/Taske/DailyLife/sqLite3Test/Database.db");
            PrintTable();
            ///Users/Rikke/Documents/GitHub/Taske/DailyLife/sqLite3Test
        }

        void PrintTable()
        {
            DataTable heya = SelectQuery("Select * From COMPANY");
            foreach (DataRow dataRow in heya.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
                
            }
        }

        public DataTable SelectQuery(string query)
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

