using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationAutomation
{
    internal class Product
    {
        public DateTime ProductDate { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductPiece { get; set; }

        public double Calculate()
        {
            return ProductPiece * ProductPrice;
        }
    }
}
