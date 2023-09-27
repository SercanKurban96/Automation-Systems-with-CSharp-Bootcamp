using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleet
{
    enum VehicleType // Araç Türü
    {
        Car, Plane, Motor
    }
    class Vehicle // Araç
    {
        public string LicensePlate { get; set; }
        public VehicleType Type { get; set; }
        public bool IsRented { get; set; }
        public DateTime RentDate { get; set; }
        public int CountOfRentalDays { get; set; }
        public double DailyRentalFee { get; set; }

        public double Hesapla()
        {
            return DailyRentalFee * CountOfRentalDays;
    }
    } 
}
