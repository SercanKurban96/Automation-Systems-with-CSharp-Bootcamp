using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                int num = Convert.ToInt32(Console.ReadLine());

                int result = 10 / num;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero error!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid a number format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurded: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
