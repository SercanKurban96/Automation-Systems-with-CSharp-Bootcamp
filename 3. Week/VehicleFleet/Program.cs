using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;

namespace VehicleFleet
{
    internal class Program
    {
        static List<Vehicle> vehicleFleet = new List<Vehicle>();
        static void Main(string[] args)
        {
            OkumaIslemi();
            vehicleFleet.Add(new Vehicle { LicensePlate = "33AKM01", Type = VehicleType.Car, DailyRentalFee = 500 });
            vehicleFleet.Add(new Vehicle { LicensePlate = "THY123", Type = VehicleType.Plane, DailyRentalFee = 1000 });
            vehicleFleet.Add(new Vehicle { LicensePlate = "MOTO345", Type = VehicleType.Motor, DailyRentalFee = 250 });

            while (true)
            {
                Console.WriteLine("1. Rent a Car");
                Console.WriteLine("2. List of vehicles available for rent");
                Console.WriteLine("3. List of rented vehicles");
                Console.WriteLine("4. Kiralanan Araçları Excel'e Aktar");
                Console.WriteLine("5. Exit");

                Console.Write("Seçiminizi Yapınız: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RentACar(); break;
                    case "2": ListOfRentableVehicles(); break;
                    case "3": ListOfRentedVehicles(); break;
                    case "4": KiralananAraclariAktar(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void RentACar()
        {
            Console.WriteLine("License plate of the vehicle to be rented: ");
            string licensePlate = Console.ReadLine();

            Vehicle rentedVehicle = vehicleFleet.FirstOrDefault(vehicle => vehicle.LicensePlate == licensePlate);

            if (rentedVehicle != null)
            {
                if (!rentedVehicle.IsRented)
                {
                    rentedVehicle.IsRented = true;
                    rentedVehicle.RentDate = DateTime.Now;

                    Console.Write("How many days do you want to rent: ");
                    int countOfRentalDays = int.Parse(Console.ReadLine());
                    double result = rentedVehicle.Hesapla();

                    rentedVehicle.CountOfRentalDays = countOfRentalDays;

                    DateTime deliveryDate = DateTime.Now.AddDays(countOfRentalDays);
                    Console.WriteLine($"{licensePlate} plakalı araç {countOfRentalDays} gün boyunca kiralandı. Kira bedeli: {result}");
                    Console.WriteLine($"Araç Teslim Tarihi: {deliveryDate}");
                }
                else
                {
                    Console.WriteLine($"{licensePlate} plakalı araç zaten kiralanmış.");
                }
            }
            else
            {
                Console.WriteLine("Bu plakada araç bulunmamaktadır.");
            }
        }

        static List<Vehicle> ListOfRentableVehicles()
        {
            Console.WriteLine("Kiralanabilir Araçlar: ");
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (var vehicle in vehicleFleet)
            {
                if (!vehicle.IsRented)
                {
                    Console.WriteLine($"License Plate: {vehicle.LicensePlate}, Type: {vehicle.Type}");
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }

        static void ListOfRentedVehicles()
        {
            Console.WriteLine("Rented Vehicles:");

            foreach (var vehicle in vehicleFleet)
            {
                if (vehicle.IsRented)
                {
                    Console.WriteLine($"License Plate: {vehicle.LicensePlate}, Type: {vehicle.Type}");
                }
            }
        }

        static void KiralananAraclariAktar()
        {
            var rentedVehicles = vehicleFleet.Where(vehicle => vehicle.IsRented).ToList();

            if (rentedVehicles.Count == 0)
            {
                Console.WriteLine("Kiralanan araç bulunamadı.");
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("KiralananAraclar");

                worksheet.Cell(1, 1).Value = "Plaka";
                worksheet.Cell(1, 2).Value = "Tür";
                worksheet.Cell(1, 3).Value = "Kiralama Tarihi";
                worksheet.Cell(1, 4).Value = "Teslim Tarihi";
                worksheet.Cell(1, 5).Value = "Kiralama Bedeli";

                for (int i = 0; i < rentedVehicles.Count; i++)
                {
                    var vehicle = rentedVehicles[i];
                    worksheet.Cell(i + 2, 1).Value = vehicle.LicensePlate;
                    worksheet.Cell(i + 2, 2).Value = vehicle.Type.ToString();
                    worksheet.Cell(i + 2, 3).Value = vehicle.RentDate;
                    worksheet.Cell(i + 2, 4).Value = vehicle.RentDate.AddDays(vehicle.CountOfRentalDays);
                    worksheet.Cell(i + 2, 5).Value = vehicle.Hesapla();

                    workbook.SaveAs("KiralananAraclar.xlsx");
                    Console.WriteLine("Kiralanan araçlar Excel dosyasına eklendi.");
                }
            }
        }
        static void OkumaIslemi()
        {
            try
            {
                using (var workbook = new XLWorkbook("KiralananAraclar.xlsx"))
                {
                    var worksheet = workbook.Worksheet(1);
                    var plateColIndex = 1;

                    foreach (var row in worksheet.RowsUsed().Skip(1))
                    {
                        string licensePlate = row.Cell(plateColIndex).Value.ToString();

                        if (!vehicleFleet.Any(vehicle => vehicle.LicensePlate == licensePlate) && !ListOfRentableVehicles().Any(vehicle => vehicle.LicensePlate == licensePlate))
                        {
                            Console.WriteLine($"Okunan araç plakası: {licensePlate}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}