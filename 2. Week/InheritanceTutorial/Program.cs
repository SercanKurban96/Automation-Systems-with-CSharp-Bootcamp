using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.longRectangle = 5;
            rectangle.widthRectangle = 3;

            double area = rectangle.calculateArea();
            Console.WriteLine($"Rectangle Area: {area}");

            Console.ReadLine();
        }
    }
}
