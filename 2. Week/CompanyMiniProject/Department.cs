using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMiniProject
{
    class Department
    {
        public string Name { get; set; }
        public string Responsible { get; set; }

        public Department(string name, string responsible)
        {
            Name = name;
            Responsible = responsible;
        }

        public void ShowEmployees()
        {
            Console.WriteLine($"Department: {Name}");
            Console.WriteLine($"Responsible: {Responsible}");
        }
    }
}
