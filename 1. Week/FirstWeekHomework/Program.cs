using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWeekHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeZoneInfo berlinTime = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"); // Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna Time Zone
            DateTime berlinTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, berlinTime);

            Console.WriteLine("Berlin Time: " + berlinTimeNow);

            Console.ReadLine();
        }
    }
}
