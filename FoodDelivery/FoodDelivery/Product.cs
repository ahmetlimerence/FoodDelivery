using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery
{
    internal abstract class Product
    {
        public double Price { get; private set; }
        public string Name { get; private set; }
        public  string CookerUserName { get; private set; }

        public Product(double price, string name, string cooker)
        {
            Price = price;
            Name = name;
            CookerUserName = cooker;
        }
    }
}
