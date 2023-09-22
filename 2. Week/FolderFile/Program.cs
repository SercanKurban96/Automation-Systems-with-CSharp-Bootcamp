using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("Enter the existing folder path: Ex. (C:\\Deneme\\): ");

                    string folderPath = Console.ReadLine();

                    if (Directory.Exists(folderPath))
                    {
                        Console.Write("Name of the file you want to add: ");
                        string fileName = Console.ReadLine();

                        Console.Write("Enter the file extension (txt, docx, xlsx...): ");
                        string extension = Console.ReadLine().ToLower();

                        if (IsValidExtension(extension))
                        {
                            string filePath = Path.Combine(folderPath, fileName + "." + extension);

                            if (File.Exists(filePath))
                            {
                                Console.WriteLine("A file with this name already exists: " + filePath);
                            }
                            else
                            {
                                try
                                {
                                    File.WriteAllText(filePath, "This is the file content text.");
                                    Console.WriteLine("File has been created." + filePath);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Folder creation error: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid file extension. Only txt, docx or xlsx extensions accepted.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("A folder with this name does not exist." + folderPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                Console.Write("Would you like to create another folder? (Yes / No): ");
            } while (Console.ReadLine().Trim().ToLower() == "yes");
        }
        static bool IsValidExtension(string extension)
        {
            string[] validExtensions = { "txt", "docx", "xlsx" };
            return validExtensions.Contains(extension);
        }
    }
}
