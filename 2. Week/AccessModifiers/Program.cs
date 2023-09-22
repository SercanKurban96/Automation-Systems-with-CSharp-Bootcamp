using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "John";

            person.InternalMethod();

            Employee employee = new Employee();
            employee.AccessProtectedMethod();
            employee.AccessPrivateProtectedMethod();

            Console.ReadKey();

            // HATALI KULLANILANLAR
            //person.age;
            //person.ProtectedMethod();
            //person.PrivateProtectedMethod();
        }
    }
}
