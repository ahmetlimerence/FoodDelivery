using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodDelivery
{
    internal class Cooker : User
    {
        private Dictionary<Product, int> _menu;
        private double _balance;
        public string CookerName;
        public Cooker(string username, string password) : base(username, password)
        {
        }
        public void GetPayment(double amounth)
        {
            _balance += amounth;
        }

        private void AddFoodTomenu(string name,int count,double price)
        {
            _menu.Add(new Food(price, name, CookerName),count);
        }

        public Dictionary<Product,int> GetMenu()
        {
            return _menu;
        }

    }
}
