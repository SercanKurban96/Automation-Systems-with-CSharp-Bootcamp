using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstWeekHomework
{
    internal class Program
    {
        static bool Login(string username, string password)
        {
            return username == "admin" && password == "12345";
        }

        static void Main(string[] args)
        {
            TimeZoneInfo berlinTime = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"); // Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna Time Zone
            DateTime berlinTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, berlinTime);

            Console.WriteLine("Berlin Time: " + berlinTimeNow);

            Console.Write("Enter Your Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Your Password: ");
            string password = Console.ReadLine();

            
            Console.WriteLine("***************EMPLOYEE SALARY CALCULATION PROGRAM***************");

            if (Login(username, password))
            {
                Console.WriteLine("Login successful. \n");
                int employeeFee = 0;

                List<Employee> employees = new List<Employee>
                {
                    new Employee("Sercan Kurban", DateTime.Now, DateTime.Now.AddHours(8),2, 8),
                    new Employee("Elif Aslan", DateTime.Now, DateTime.Now.AddHours(10), 3, 10),
                    new Employee("Yusuf Kandemir", DateTime.Now, DateTime.Now.AddHours(9), 2, 9)
                };

                Console.WriteLine("Employees: ");
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.NameSurname);
                }
                Console.Write("\nWhich employee do you want to choose? (Enter Employee Name): ");
                string selectedEmployeeName = Console.ReadLine();

                Employee selectedEmployee = null;
                foreach (var employee in employees)
                {
                    if (employee.NameSurname == selectedEmployeeName)
                    {
                        selectedEmployee = employee;
                        break;
                    }
                }

                if (selectedEmployee != null)
                {
                    Console.WriteLine($"\n{selectedEmployee.NameSurname} employee was chosen.");
                    int workOff = selectedEmployee.WorkOff.AddHours(selectedEmployee.TotalWorkTime).Hour;
                    int workStart = selectedEmployee.WorkStart.Hour;

                    if (selectedEmployee.TotalWorkTime <= 8)
                    {
                        employeeFee = ((selectedEmployee.TotalWorkTime) - selectedEmployee.WorkBreak) * 50;
                        Console.WriteLine($"Employee Name Surname: {selectedEmployee.NameSurname}");
                        Console.WriteLine($"Work Start Date: {selectedEmployee.WorkStart}");
                        Console.WriteLine($"Work Off Date: {selectedEmployee.WorkOff}");
                        Console.WriteLine($"Work Break Duration: {selectedEmployee.WorkBreak}");
                        Console.WriteLine($"Total Work Time: {selectedEmployee.TotalWorkTime}");
                        Console.WriteLine($"Employee Fee: {employeeFee}");

                    }
                    else
                    {
                        int overtime = (selectedEmployee.TotalWorkTime) - 8;
                        int workingHourWage = overtime * 60;
                        employeeFee = ((8 - selectedEmployee.WorkBreak) * 50) + workingHourWage;
                        Console.WriteLine($"Employee Name Surname: {selectedEmployee.NameSurname}");
                        Console.WriteLine($"Work Start Date: {selectedEmployee.WorkStart}");
                        Console.WriteLine($"Work Off Date: {selectedEmployee.WorkOff}");
                        Console.WriteLine($"Work Break Duration: {selectedEmployee.WorkBreak}");
                        Console.WriteLine($"Total Work Time: {selectedEmployee.TotalWorkTime}");
                        Console.WriteLine($"Employee Fee: {employeeFee}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Employee Name");
                }
            }
            else
            {
                Console.WriteLine("Invalid Username or Password");
            }
            Console.ReadLine();
        }

        class Employee
        {
            public Employee(string nameSurname, DateTime workStart, DateTime workOff, int workBreak, int totalWorkTime)
            {
                NameSurname = nameSurname;
                WorkStart = workStart;
                WorkOff = workOff;
                WorkBreak = workBreak;
                TotalWorkTime = totalWorkTime;
            }

            public string NameSurname { get; }
            public DateTime WorkStart { get; }
            public DateTime WorkOff { get; }
            public int WorkBreak { get; }
            public int TotalWorkTime { get; }
        }
    }
}
