using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GasStationAutomation
{
    internal class Program
    {
        static List<Product> products = new List<Product>();
        static void ShowMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Water ---> 5 ₺");
            Console.WriteLine("2 - Chocolate ---> 10 ₺");
            Console.WriteLine("3 - Biscuit ---> 15 ₺");
            Console.WriteLine("4 - Crisps ---> 20 ₺");
            Console.WriteLine("*****************************");
        }
        static void Main(string[] args)
        {
            string validUsername = "sercan";
            string validPassword = "123";
            int accessFailedCount = 0;

            while (accessFailedCount < 3)
            {
                Console.Write("Enter Your Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Your Password: ");
                string password = Console.ReadLine();

                if (username == validUsername && password == validPassword)
                {
                    Console.WriteLine($"Welcome {validUsername}.");
                    Console.WriteLine("Check-in Date and Time: " + DateTime.Now);

                    products.Add(new Product { ProductDate = DateTime.Now, ProductName = "Water", ProductPrice = 5, ProductPiece = 500 });
                    products.Add(new Product { ProductDate = DateTime.Now, ProductName = "Chocolate", ProductPrice = 10, ProductPiece = 400 });
                    products.Add(new Product { ProductDate = DateTime.Now, ProductName = "Biscuit", ProductPrice = 15, ProductPiece = 300 });
                    products.Add(new Product { ProductDate = DateTime.Now, ProductName = "Crisps", ProductPrice = 20, ProductPiece = 200 });

                    while (true)
                    {
                        Console.WriteLine("1 - Show Menu");
                        Console.WriteLine("2 - Make a Sale");
                        Console.WriteLine("3 - Save Data to Excel");
                        Console.WriteLine("4 - Quit");
                        Console.Write("Please enter the transaction you want to perform: ");

                        int choice;

                        if (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Invalid choice! Try again.");
                        }

                        switch (choice)
                        {
                            case 1:
                                ShowMenu();
                                break;
                            case 2:
                                ShowMenu();
                                SellProduct();
                                break;
                            case 3:
                                SaveExcel();
                                break;
                            case 4:
                                Console.WriteLine("Exiting...");
                                Thread.Sleep(2000);
                                Console.Beep();
                                return;
                            default:
                                Console.WriteLine("Invalid an option.");
                                break;
                        }
                    }
                }
                else
                {
                    accessFailedCount++;
                    Console.WriteLine("Access Denied! Login Remaining: " + (3 - accessFailedCount));
                }
            }
            if (accessFailedCount >= 3)
            {
                Console.WriteLine("Your account has been blocked. The program will terminate within 2 seconds.");
                Thread.Sleep(2000);
                Console.Beep();
                Environment.Exit(0);
            }
        }

        static void SellProduct()
        {
            Console.Write("Select the product you want to sell: ");
            string selectedProduct = Console.ReadLine();

            Product product = products.FirstOrDefault(x => x.ProductName == selectedProduct);

            if (product != null)
            {
                Console.Write("How many piece do you want to sell: ");
                int piece = Convert.ToInt32(Console.ReadLine());
                int remain = product.ProductPiece - piece;
                double price = product.ProductPrice * piece;

                if (remain <= 0)
                {
                    Console.WriteLine("The product you want is out of stock.");
                }
                else
                {
                    product.ProductDate = DateTime.Now;
                    Console.WriteLine($"The product sale was successful. Total Amount: {price}");
                    Console.WriteLine($"Stock Remain: {remain}");
                }
            }
            else
            {
                Console.WriteLine("There is no such product.");
            }
        }
        static void SaveExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datas");
                worksheet.Cell(1, 1).Value = "Product Date";
                worksheet.Cell(1, 2).Value = "Product Name";
                worksheet.Cell(1, 3).Value = "Product Price";
                worksheet.Cell(1, 4).Value = "Product Piece";

                for (int i = 0; i < products.Count; i++)
                {
                    var product = products[i];
                    worksheet.Cell(i + 2, 1).Value = product.ProductDate;
                    worksheet.Cell(i + 2, 2).Value = product.ProductName;
                    worksheet.Cell(i + 2, 3).Value = product.ProductPrice;
                    worksheet.Cell(i + 2, 4).Value = product.ProductPiece;

                    workbook.SaveAs("Products.xlsx");
                    Console.WriteLine("The products have been successfully added to the Excel file.");
                }
            }
        }
    }
}
