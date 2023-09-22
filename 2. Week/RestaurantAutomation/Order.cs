using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAutomation
{
    internal class Order
    {       
        public List<Product> Orders { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Order()
        {
            Orders = new List<Product>();
            TotalPrice = 0;
        }

        public void AddProduct(Product product)
        {
            Orders.Add(product);
            TotalPrice += product.Price;
        }

        public void PayTheBill()
        {
            Console.WriteLine("Total Account: " + TotalPrice);
        }

    }
}
