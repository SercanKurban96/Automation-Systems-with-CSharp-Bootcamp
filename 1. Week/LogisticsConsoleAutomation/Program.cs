using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogisticsConsoleAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KURBAN LLC.");

            TimeZoneInfo berlinTime = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"); // Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna Time Zone
            DateTime berlinTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, berlinTime);
            Console.WriteLine("Berlin Time: " + berlinTimeNow);

            Console.Write("Enter Your Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Your Password: ");
            string password = Console.ReadLine();

            if (Login(username, password))
            {
                Console.WriteLine("Login successful. \n");

                List<Truck> trucks = new List<Truck>
                {
                    new Truck("Sercan", "Grape", "Istanbul", 2, DateTime.Now.AddHours(1)),
                    new Truck("Ahmet", "Watermelon", "Diyarbakır", 3, DateTime.Now.AddHours(2)),
                    new Truck("Yusuf", "Simit", "İzmir", 4, DateTime.Now.AddHours(3))
                };

                Console.WriteLine("Trucks: ");
                foreach (var truck in trucks)
                {
                    Console.WriteLine(truck.Name);
                }
                Console.Write("\nWhich truck do you want to choose? (Enter Truck Name): ");
                string selectedTruckName = Console.ReadLine();

                Truck selectedTruck = null;
                foreach (var truck in trucks)
                {
                    if (truck.Name == selectedTruckName)
                    {
                        selectedTruck = truck;
                        break;
                    }
                }

                if (selectedTruck != null)
                {
                    Console.WriteLine($"\n{selectedTruck.Name} truck was chosen.");
                    Console.WriteLine($"Transported Product: {selectedTruck.Product}");
                    Console.WriteLine($"Destination City: {selectedTruck.City}");
                    DateTime arrivalTime = selectedTruck.DepartureTime.AddHours(selectedTruck.ArrivalTime);
                    Console.WriteLine($"Estimated Time of Arrival: {arrivalTime}");

                    TimeSpan standbyTime = selectedTruck.DepartureTime - DateTime.Now;
                    Console.WriteLine($"\nTruck Departure Time: {standbyTime.ToString().Substring(0, 5)}");
                    Thread.Sleep(standbyTime);
                    Console.WriteLine("\nThe truck is moving.");
                }
                else
                {
                    Console.WriteLine("Invalid Truck Name");
                }
            }
            else
            {
                Console.WriteLine("Invalid Username or Password");
            }

            Console.ReadLine();
        }

        static bool Login(string username, string password)
        {
            return username == "admin" && password == "12345";
        }

        class Truck
        {
            public Truck(string name, string product, string city, int arrivalTime, DateTime departureTime)
            {
                Name = name;
                Product = product;
                City = city;
                ArrivalTime = arrivalTime;
                DepartureTime = departureTime;
            }

            public string Name { get; set; }
            public string Product { get; set; }
            public string City { get; set; }
            public int ArrivalTime { get; set; }
            public DateTime DepartureTime { get; set; }
        }
    }
}
