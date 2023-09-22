using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company("Sercan Company");

            Department humanResources = new Department("Human Resources", "Sercan Kurban");
            company.AddDepartment(humanResources);

            Department accountant = new Department("Accountant", "Ahmet Kaya");
            company.AddDepartment(accountant);

            Department technology = new Department("Technology", "Utku Paralı");
            company.AddDepartment(technology);

            Console.WriteLine($"Company Name: {company.Name}");
            foreach (var department in company.Department)
            {
                department.ShowEmployees();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
