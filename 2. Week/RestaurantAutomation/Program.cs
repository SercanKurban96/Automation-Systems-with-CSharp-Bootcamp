using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Order order = new Order();

            menu.OrderHasBeenTaken += (ord) => { ord.PayTheBill(); };

            while (true)
            {
                menu.ShowMenu();
                Console.Write("Make your choice (1-4): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                menu.TakeOrder(choice, order);
            }
        }
    }
}
