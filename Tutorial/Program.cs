using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Factorial
            Console.Write("Enter the number you want to calculate the factorial: ");
            int num = Convert.ToInt32(Console.ReadLine());

            long factorial = FactorialCalculate(num);
            Console.WriteLine($"{num}! = {factorial}");

            Console.ReadLine();
        }

        static long FactorialCalculate(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial of negative numbers cannot be taken.");
            }
            else if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                long factorial = 1;
                for (int i = 2; i <= n; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }                 
        }
    }
}
