﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string validUsername = "sercan";
            string validPassword = "123";
            int accessFailedCount = 0;
            DateTime? lastAccessFailedTime = null;

            while (accessFailedCount < 3)
            {
                Console.Write("Enter Your Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Your Password: ");
                string password = Console.ReadLine();

                if (username == validUsername && password == validPassword)
                {
                    Console.WriteLine($"Welcome {validUsername}.");
                    Console.WriteLine("Check-in Date and Time: " + DateTime.Now);

                    if (lastAccessFailedTime.HasValue)
                    {
                        Console.WriteLine("Last Incorrect Login Date and Time: " + lastAccessFailedTime);
                    }
                    break; // When I entered username and password correctly, I exited the loop.
                }
                else
                {
                    accessFailedCount++;
                    Console.WriteLine("Access Denied! Login Remaining: " + (3 - accessFailedCount));
                    lastAccessFailedTime = DateTime.Now;
                }
            }
            if (accessFailedCount >= 3)
            {
                Console.WriteLine("Your account has been blocked. The program will terminate within 2 seconds.");
                Thread.Sleep(2000);
                Console.Beep();
                Environment.Exit(0);              
            }
            Console.ReadLine();
        }
    }
}
