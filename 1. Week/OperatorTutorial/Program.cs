using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arithmetic Operators

            /*
             + Plus
             - Minus
             * Multiplication
             / Divide
             % Mod
             */

            //int num1 = 10;
            //int num2 = 20;

            //int total = num1 + num2;
            //int difference = num1 - num2;
            //int multiply = num1 * num2;
            //int divide = num1 / num2;
            //int remainder = num1 % num2;
            //Console.WriteLine($"Total: {total}");
            //Console.WriteLine($"Difference: {difference}");
            //Console.WriteLine($"Multiply: {multiply}");
            //Console.WriteLine($"Divide: {divide}");
            //Console.WriteLine($"Remainder: {remainder}");

            // Assignment Operators
            /*
             = assignment
             += Plus and assignment
             -= Minus and assignment
             *= Multiplication and assignment
             /= Divide and assignment
             */

            //int x = 5;
            //x += 3;
            //x -= 3;
            //x *= 3;
            //x /= 3;
            //Console.WriteLine($"x: {x}");

            // Comparison Operators

            /*
             == Equality
             != Not equality
             < is smaller than
             > is greater than
             <= is smaller than or equal
             >= is bigger than or equal
             */

            //int numA = 10;
            //int numB = 5;
            //bool isEqual = numA == numB;
            //bool isNotEqual = numA != numB;
            //bool isGreater = numA > numB;
            //bool isSmaller = numA < numB;

            //Console.WriteLine($"Is Equal: {isEqual}");
            //Console.WriteLine($"Is Not Equal: {isNotEqual}");
            //Console.WriteLine($"Is Greater Than: {isGreater}");
            //Console.WriteLine($"Is Smaller Than: {isSmaller}");

            // Logical Operators

            /*
             && (AND) precision
             || (OR) in between
             ! (NOT)
             */

            //bool condition1 = true;
            //bool condition2 = false;

            //bool result1 = condition1 && condition2;
            //bool result2 = condition1 || condition2;
            //bool result3 = !condition1;

            //Console.WriteLine($"Result 1: {result1}");
            //Console.WriteLine($"Result 2: {result2}");
            //Console.WriteLine($"Result 3: {result3}");

            // Increase and Decrease

            /*
             ++ (Increase)
             -- (Decrease)
             */

            //int a = 5;
            //a++;
            //a--;
            //Console.WriteLine($"a: {a}");

            // Condition Operator ?

            //int age = 18;
            //string result = (age >= 18) ? "Can get a driver license." : "Can't get a driver license.";
            //Console.WriteLine($"Result: {result}");

            // Conditionals if - else if - else

            //int ageA = 20;
            //if (ageA >= 18)
            //{
            //    Console.WriteLine("Can get a driver license.");
            //}
            //else if (ageA >= 16)
            //{
            //    Console.WriteLine("Can get a motor driver license.");
            //}
            //else
            //{
            //    Console.WriteLine("Can't get a driver license.");
            //}

            // Switch - Case (Branching)

            //Console.Write("Your favourite fruit: ");
            //string fruit = Console.ReadLine();

            //switch (fruit.ToLower())
            //{
            //    case "apple":
            //        Console.WriteLine("Apple is loved.");
            //        break;
            //    case "pear":
            //        Console.WriteLine("Pear is loved.");
            //        break;
            //    case "banana":
            //        Console.WriteLine("Banana is loved");
            //        break;
            //    default:
            //        Console.WriteLine("I heard the name of the fruit you entered for the first time.");
            //        break;
            //}

            // Loops

            /*
             for Loop
             while Loop
             do-while Loop
             foreach Loop
             */

            // For Loop
            Console.WriteLine("********************FOR LOOP********************");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Loop is running. Iteration: " + i);
            }

            // While Loop
            Console.WriteLine("********************WHILE LOOP********************");
            int count = 0;
            while (count < 5)
            {
                Console.WriteLine("Loop is running. Count: " + count);
                count++;
            }

            // Do-While Loop
            Console.WriteLine("********************DO-WHILE LOOP********************");
            int count2 = 0;
            do
            {
                Console.WriteLine("Loop is running. Count: " + count2);
                count2++;
            } while (count2 < 5);

            // Foreach Loop
            Console.WriteLine("********************FOREACH LOOP********************");
            string[] names = { "Sercan", "Ahmet", "Yusuf", "Yeliz" };
            foreach (string name in names)
            {
                Console.WriteLine("Name: " + name);
            }

            Console.Read();
        }
    }
}
