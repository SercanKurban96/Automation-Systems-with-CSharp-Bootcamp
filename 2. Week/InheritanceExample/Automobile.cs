using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Automobile : Vehicular
    {
        public Automobile(string brand, string model, int year) : base(brand, model, year)
        {
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} automobile started.");
        }

        public void SoundHorn()
        {
            Console.WriteLine($"{Brand} {Model} automobile is honking its horn.");
        }
    }
}
