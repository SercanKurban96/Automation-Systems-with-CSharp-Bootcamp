using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOvertimeTracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();

            while (true)
            {
                Console.WriteLine("1. Employee Entrance");
                Console.WriteLine("2. Employee Exit");
                Console.WriteLine("3. Exiting the Program");
                Console.Write("Choose an option. (A numerical value): ");

                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1: EmployeeEntrance(employeeList); break;
                    case 2: EmployeeExit(employeeList); break;
                    case 3: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a value between 1-3.");
                        break;
                }
            }
        }

        static void EmployeeEntrance(List<Employee> employeeList)
        {
            Console.Write("Giriş Yapan Personel Adı: ");
            string name = Console.ReadLine();

            if (employeeList.Exists(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{name} şu anda çalışıyor.");
                return;
            }

            DateTime entryTime = DateTime.Now;

            TimeZoneInfo germanyHour = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime berlinEntryTime = TimeZoneInfo.ConvertTime(entryTime, germanyHour);

            Employee employee = new Employee()
            {
                Name = name,
                EntryTime = berlinEntryTime,
            };

            employeeList.Add(employee);
            Console.WriteLine($"{name} saat {berlinEntryTime:HH:mm:ss} itibariyle giriş yaptı.");
        }

        static void EmployeeExit(List<Employee> employeeList)
        {
            Console.Write("Çıkış Yapan Personel Adı: ");
            string name = Console.ReadLine();
            DateTime entryTime = DateTime.Now;

            TimeZoneInfo germanyHour = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime berlinExitTime = TimeZoneInfo.ConvertTime(entryTime, germanyHour);

            foreach (var employee in employeeList)
            {
                if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    TimeSpan overtimeHours = berlinExitTime - employee.EntryTime;
                    double overtimeFee = overtimeHours.TotalHours * 50;

                    Console.WriteLine($"{name} saat {berlinExitTime: HH:mm:ss} itibariyle çıkış yaptı.");
                    Console.WriteLine($"Mesai Süresi: {overtimeHours.TotalHours} saat.");
                    Console.WriteLine($"Mesai Ücreti: {overtimeFee} $");

                    employeeList.Remove(employee);
                    return;
                }
            }
            Console.WriteLine("Girmiş olduğunuz personel mesaiye kalmamıştır.");
        }

        class Employee
        {
            public string Name { get; set; }
            public DateTime EntryTime { get; set; }
        }
    }
}
