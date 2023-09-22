using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTutorial
{
    //Alt Sınıf (Derived Class)
    class Rectangle : Shape
    {
        public double longRectangle { get; set; }
        public double widthRectangle { get; set; }

        public override double calculateArea()
        {
            return longRectangle * widthRectangle;
        }
    }
}
