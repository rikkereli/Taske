using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagligdagen
{
    public delegate string Input();
    public delegate void Output(string s);
    class TempTestClass
    {
        public void TestMakeList()
        {
            string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Transactions\\TestTransactionsTwoWithTwoIsRight.txt";
            string productFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\Products\\TestProductsWithTwoProductsIsRight.txt";
            string standardDiscardProductFile = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\TestDokumenter\\WriteToProducts\\StandardDiscardProductFile.txt";
            System.IO.File.WriteAllText(standardDiscardProductFile, string.Empty);
            ListOfProducts listOfProducts = new ListOfProducts(productFilePath);
            listOfProducts.AddProduct("Mælk", UnitType.l, ProductType.Food);
            listOfProducts.AddProduct("Kage", UnitType.kg, ProductType.Snack);
            ListOfTransactions transactions = new ListOfTransactions(ReadFromFiles.ReadFromTransactionFileToListOfTransactions(transactionFilePath, listOfProducts, standardDiscardProductFile), transactionFilePath);

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
        }
        
        static public void TestIfProgramRuns()
        {
            string transactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\Transactions.txt";
            string productFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\Products.txt";
            string discardedTransactionFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\DiscardedTransactions.txt";
            string discardedProductFilePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\DiscardedProducts.txt";
            UserInterfaceConsole uI = new UserInterfaceConsole(new DailyLifeSystem(productFilePath, discardedProductFilePath, transactionFilePath, discardedTransactionFilePath));
            uI.Run();
        }

        static public void TestIfDelegateWorks()
        {
            Input input = Three;
            Console.WriteLine(input());
            input = Console.ReadLine;
            Console.WriteLine(input());
            input = Hello;
            Console.WriteLine(input());
        }
        static public string Three() { return "3"; }
        static public string Five() => "5";
        static public string Hello() => "Hello";
    }
}
