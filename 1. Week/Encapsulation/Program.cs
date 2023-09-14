using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal class Program
    {
        // Private Fields

        //private string brand, model;
        ////private string model;
        //private int speed;
        //public Program(string brand, string model)
        //{
        //    this.brand = brand;
        //    this.model = model;
        //    this.speed = 0;
        //}

        //public void IncreaseSpeed(int increaseAmount)
        //{
        //    if (increaseAmount > 0)
        //    {
        //        speed += increaseAmount;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid speed increase amount!");
        //    }
        //}

        //public void DecreaseSpeed(int decreaseAmount)
        //{
        //    if (decreaseAmount > 0)
        //    {
        //        speed -= decreaseAmount;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid speed decrease amount!");
        //    }
        //}

        //public void ShowStatus()
        //{
        //    Console.WriteLine($"Brand: {brand}, Model: {model}, Speed: {speed} km/h");
        //}


        private string accountHolder;
        private double balance;

        public Program(string accountHolder, double balance)
        {
            this.accountHolder = accountHolder;
            this.balance = balance;
        }

        public void depositMoney(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"{amount:C2} Turkish Lira was deposited into the account named {accountHolder}. New balance: {balance:C2}");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }

        public void withdrawMoney(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"The account named {accountHolder} withdrew {amount:C2} Turkish Lira. New balance: {balance:C2}");
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient funds!");
            }
        }

        public void showAccountInformation()
        {
            Console.WriteLine($"Account Holder: {accountHolder}");
            Console.WriteLine($"Balance: {balance}");
        }

        static void Main(string[] args)
        {
            //Program car1 = new Program("Toyota", "Corolla");
            //car1.ShowStatus();

            //car1.IncreaseSpeed(50);
            //car1.ShowStatus();

            //car1.DecreaseSpeed(10);
            //car1.ShowStatus();

            Program account1 = new Program("Sercan Kurban", 1000);
            account1.showAccountInformation();

            account1.depositMoney(500.0);
            account1.showAccountInformation();

            account1.withdrawMoney(200.0);
            account1.showAccountInformation();

            Console.Read();
        }
    }
}
