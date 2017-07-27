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
        string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\TestTransactions.txt";

        ListOfProducts listOfProducts = new ListOfProducts();
        listOfProducts.AddProduct("Mælk", UnitType.l, ProductType.Food);
        listOfProducts.AddProduct("Kage", UnitType.kg, ProductType.Snack);
        ListOfTransactions transactions = ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, listOfProducts);

        Console.WriteLine(Product.TableExplanation());
        foreach (Product product in listOfProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine(Transaction.TableExplanation());
        foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        Console.ReadKey();
        }
    }
}
