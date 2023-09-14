using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DateTime  TimeSpan

            //DateTime now = DateTime.Now; // Gets the current date and time.
            //DateTime tomorrow = new DateTime(2023, 09, 12);
            //TimeSpan diff = tomorrow - now;

            //// DateTimeOffset

            //DateTimeOffset dtOffset = DateTimeOffset.Now;

            //// TimeZone

            //TimeZoneInfo istanbulTime = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"); // Istanbul Time Zone
            //DateTime istanbulTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, istanbulTime);

            //// System.Diagnostics.Stopwatch

            //Stopwatch stopup = new Stopwatch();
            //stopup.Start(); // Time started

            //// I completed the transactions.

            //stopup.Stop(); // I stopped time.
            //TimeSpan passingTime = stopup.Elapsed; // Get elapsed time




            //Console.WriteLine("Time Operations Project. \n");

            //// Get Current Date
            //DateTime startTime = DateTime.Now;
            //Console.WriteLine("Start Time: " + startTime);

            //// Wait for a certain period of time
            //int waitingTime = 5;
            //Console.WriteLine($"The program waits for {waitingTime} seconds...");
            //Thread.Sleep(waitingTime * 1000);

            //// Calculate elapsed time
            //DateTime endTime = DateTime.Now;
            //TimeSpan passingTime = endTime - startTime;
            //Console.WriteLine("End Time: " + endTime);
            //Console.WriteLine("Passing Time: " + passingTime.TotalSeconds + " seconds...");

            //Console.WriteLine("*******************************************************");

            // break - continue

            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 5)
            //    {
            //        Console.WriteLine("Loop ends.");
            //        break;
            //    }
            //    Console.WriteLine(i);
            //}

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{i} is an even number.");
                    continue;
                }
                Console.WriteLine($"{i} is an odd number.");
            }

            Console.ReadLine();
        }
    }
}
