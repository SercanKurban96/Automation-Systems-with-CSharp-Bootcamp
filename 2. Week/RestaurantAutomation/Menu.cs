using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAutomation
{
    internal class Menu
    {
        public delegate void OrderEventHandler(Order order);
        public event OrderEventHandler OrderHasBeenTaken;
        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Pizza ---> 20 ₺");
            Console.WriteLine("2. Burger ---> 30 ₺");
            Console.WriteLine("3. Lahmacun ---> 15 ₺");
            Console.WriteLine("4. Pay the Bill");
        }

        public void TakeOrder(int choice, Order order)
        {
            switch (choice)
            {
                case 1: order.AddProduct(new Product("Pizza", 20)); break;
                case 2: order.AddProduct(new Product("Burger", 30)); break;
                case 3: order.AddProduct(new Product("Lahmacun", 15)); break;
                case 4:
                    if (OrderHasBeenTaken != null)
                    {
                        OrderHasBeenTaken(order);
                    }; break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
