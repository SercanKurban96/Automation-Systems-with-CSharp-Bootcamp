using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorDelegate sumDelegate = Calculator.Sum;
            CalculatorDelegate subtractDelegate = Calculator.Subtract;

            sumDelegate(5, 8);
            subtractDelegate(5, 3);

            CalculatorDelegate calculateDelegate = sumDelegate + subtractDelegate;
            calculateDelegate(5, 2);

            Console.ReadLine();
        }
    }
}
