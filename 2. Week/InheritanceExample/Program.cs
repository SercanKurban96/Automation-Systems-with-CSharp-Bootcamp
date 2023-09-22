using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Automobile automobile = new Automobile("Toyota", "Corolla", 2023);
            automobile.Start();
            automobile.SoundHorn();
            automobile.Stop();

            Console.ReadLine();
        }
    }
}
