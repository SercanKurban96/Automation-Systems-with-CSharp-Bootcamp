using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Filing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string filePath = @"C:\Deneme\file.txt";
            //string text = "This file was created with C#";

            //File.WriteAllText(filePath, text);

            //FileStream file = File.Create(filePath); // Dosyayı oluşturmak için kullanılır.
            //file.Close(); // Dosyayı kapatmak için kullanılır.

            // FOLDER CREATION

            //string mainFolderPath = @"C:\Deneme\";
            //string folderName = "NewFolder";

            //string folderPath = Path.Combine(mainFolderPath, folderName);

            //try
            //{
            //    Directory.CreateDirectory(folderPath);
            //    Console.WriteLine("Folder has been created: " + folderPath);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Folder creation error: " + ex.Message);
            //}

            do
            {
                Console.Write("Enter the folder name you want to create: ");
                string folderName = Console.ReadLine();

                string mainFolderPath = @"C:\Deneme\";
                string folderPath = Path.Combine(mainFolderPath, folderName);

                if (Directory.Exists(folderPath))
                {
                    Console.WriteLine("A folder with this name already exists." + folderPath);
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(folderPath);
                        Console.WriteLine("Folder has been created: " + folderPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Folder creation error: " + ex.Message);
                    }
                    Console.Write("Would you like to create another folder? (Yes / No): ");
                }
            } while (Console.ReadLine().Trim().ToLower() == "yes");
        }
    }
}
