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
            string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Transactions\\TestTransactionsTwoWithTwoIsRight.txt";
            string productFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Products\\TestProductsWithTwoProductsIsRight.txt";
            string standardDiscardProductFile = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\WriteToProducts\\StandardDiscardProductFile.txt";
            System.IO.File.WriteAllText(standardDiscardProductFile, string.Empty);
            ListOfProducts listOfProducts = new ListOfProducts();
        listOfProducts.AddProduct("Mælk", UnitType.l, ProductType.Food);
        listOfProducts.AddProduct("Kage", UnitType.kg, ProductType.Snack);
        ListOfTransactions transactions = new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, listOfProducts));

            List<Product> products = ReadFromFiles.ReadFromProductfileToListOfProducts(productFilePath, standardDiscardProductFile);
        Console.WriteLine(Product.TableExplanation());
            Console.WriteLine(System.IO.File.ReadAllText(productFilePath));

            Console.WriteLine(System.IO.File.ReadAllText(standardDiscardProductFile));
            foreach (Product product in products)
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
