using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Variables

            //// Integer Variables
            //// long, int, short, byte

            //int age = 27;
            //Console.WriteLine("Your Age: " + age);
            //Console.ReadKey();

            //// Decimal Variables
            //// float, double, decimal

            //double noteAverage = 88.5;
            //Console.WriteLine("Your Note Average: " + noteAverage);
            //Console.ReadKey();

            //// String Variable
            //// string

            //string name = "Sercan";
            //Console.WriteLine("Your Name: " + name);
            //Console.ReadKey();

            //// Character Variable
            //// char

            //char character = 'A';
            //Console.WriteLine("Desired Character: " + character);
            //Console.ReadKey();

            //// Logical Variable
            //// bool

            //bool isTrue = true;
            //Console.WriteLine("Is It True? " + isTrue);
            //Console.ReadKey();

            // Let's ask the user for some information.
            Console.Write("Student's Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Student's Age: ");
            int studentAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Is Active? (Yes/No): ");
            bool studentActive = Console.ReadLine().Equals("Yes", StringComparison.OrdinalIgnoreCase);

            Console.WriteLine("\n Student Information");
            Console.WriteLine("Student's Name: " + studentName);
            Console.WriteLine("Student's Age: " + studentAge);
            Console.WriteLine("Active: " + studentActive);

            Console.WriteLine("\nProgram terminated. Press any key to close.");
            Console.ReadKey();

        }
    }
}
