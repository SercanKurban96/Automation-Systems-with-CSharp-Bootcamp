using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMiniProject
{
    class Company
    {
        public string Name { get; set; }
        public List<Department> Department { get; set; }

        public Company(string name)
        {
            Name = name;
            Department = new List<Department>();
        }

        public void AddDepartment(Department department)
        {
            Department.Add(department);
        }

    }
}
