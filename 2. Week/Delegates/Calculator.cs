using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void CalculatorDelegate(int x, int y);
    internal class Calculator
    {
        public static void Sum(int x, int y)
        {
            Console.WriteLine($"Sum: {x + y}");
        }

        public static void Subtract(int x, int y)
        {
            Console.WriteLine($"Diff: {x - y}");
        }
    }
}
