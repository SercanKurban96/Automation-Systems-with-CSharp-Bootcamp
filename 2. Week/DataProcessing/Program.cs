using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Klasör Oluşturma");
                Console.WriteLine("2 - Dosya Oluşturma");
                Console.WriteLine("3 - Dosyaya Veri Ekleme");
                Console.WriteLine("4 - Dosyadan Veri Çekme");
                Console.WriteLine("5 - Çıkış");
                Console.Write("Yapmak İstediğiniz İşlemi Seçin: ");

                int secim;
                if (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > 5)
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    continue;
                }

                switch (secim)
                {
                    case 1: CreateFolder(); break;
                    case 2: CreateFile(); break;
                    case 3: AddingDataToFile(); break;
                    case 4: RaadingDataFromFile(); break;
                    case 5: Environment.Exit(0); break;
                    default: Console.WriteLine("Invalid an option."); break;
                }
            }
        }

        static void CreateFolder()
        {
            Console.Write("Enter the existing folder path: Ex. (C:\\Deneme\\): ");
            string folderPath = Console.ReadLine();

            Console.Write("Enter a folder name: ");
            string folderName = Console.ReadLine();

            string fullFolderPath = Path.Combine(folderPath, folderName);

            if (Directory.Exists(fullFolderPath))
            {
                Console.WriteLine("A folder with this name already exists: " + folderPath);
            }
            else
            {
                Directory.CreateDirectory(fullFolderPath);
                Console.WriteLine("Folder has been created." + fullFolderPath);
            }
        }

        static void CreateFile()
        {
            Console.Write("Enter the folder path where the file will be created: ");
            string folderPath = Console.ReadLine();

            Console.Write("Enter a file name: ");
            string fileName = Console.ReadLine();

            string fullFilePath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullFilePath))
            {
                Console.WriteLine("A file with this name already exists: " + folderPath);
            }
            else
            {
                File.Create(fullFilePath);
                Console.WriteLine("File has been created." + fullFilePath);
            }
        }

        static void AddingDataToFile()
        {
            Console.Write("Enter the path to the file to which you want to add data: ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("The specified file was not found!");
                return;
            }
            Console.Write("Enter a data: ");
            string data = Console.ReadLine();

            File.AppendAllText(fileName, data);
            Console.WriteLine("Data added to the file.");
        }

        static void RaadingDataFromFile()
        {
            Console.Write("Enter the path to the file to which you want to add data: ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("The specified file was not found!");
                return;
            }

            string readData = File.ReadAllText(fileName);
            Console.WriteLine("Data read from file: " + readData);
        }
    }
}
