using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Vehicular
    {      
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Vehicular(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public virtual void Start()
        {
            Console.WriteLine($"{Brand} {Model} started.");
        }

        public void Stop()
        {
            Console.WriteLine($"{Brand} {Model} stopped.");
        }
    }
}
