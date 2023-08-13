using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery
{
    internal class Food : Product
    {
        public Food(double price, string name, string cooker) : base(price, name, cooker)
        {

        }
    }
}
