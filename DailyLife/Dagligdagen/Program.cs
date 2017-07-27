using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    class Program
    {
        static void Main(string[] args)
        {
        string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Transactions.txt";

        ListOfProducts listOfProducts = new ListOfProducts();
        listOfProducts.AddProductFromStartup("Mælk", UnitType.l, ProductType.Food, 1);
        listOfProducts.AddProductFromStartup("Kage", UnitType.kg, ProductType.Snack, 2);
        ListOfTransactions transactions = ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, listOfProducts);
      
        Console.ReadKey();
        }
    }
}
