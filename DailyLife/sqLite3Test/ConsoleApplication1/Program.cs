using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Miiiin min = new Miiiin();

            Console.ReadKey();
        }

        class Miiiin {
            /// <summary>
            /// :'(
            /// </summary>
            public void RikkeErKedAfDet()
            {
                DataTable MikkelErEnÆblekage = SelectQuery("INSERT INTO RikkeErSejereEndMikkel VALUES(2,'Æblekage',2000);");
            }

            private SQLiteConnection sqlite;

            public Miiiin()
            {
                sqlite = new SQLiteConnection("Data Source=C:/Users/Rikke/Documents/GitHub/Taske/DailyLife/sqLite3Test/DJDatabase.db");
                PrintTable();
                ///Users/Rikke/Documents/GitHub/Taske/DailyLife/sqLite3Test
            }

            public void PrintTable()
            {
                DataTable heya = SelectQuery("Select * From RikkeErSejereEndMikkel");
                {
                    foreach (DataRow dataRow in heya.Rows)
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
}
