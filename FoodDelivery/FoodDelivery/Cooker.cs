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

        private void AddFoodToMenu(string name,int count,double price)
        {
            _menu.Add(new Food(price, name, CookerName),count);
        }

        public Dictionary<Product,int> GetMenu()
        {
            return _menu;
        }

        private void RemoveProductFromMenu(Product product)
        {
            if(IsMenuHasProduct(product))
            {
                _menu.Remove(FindSameProduct(product));
                return;
            }
            return;
        }

        private void DecreaseProduct(Product key, int count)
        {
            if(IsMenuHasProduct(key))
            {
                if(_menu[FindSameProduct(key)] > count)
                {
                    _menu[FindSameProduct(key)] -= count;
                }
                else if (_menu[FindSameProduct(key)] == count)
                {
                    RemoveProductFromMenu(key);
                }
                else
                {
                    return;
                }

            }
        }

        private void IncreaseProduct(Product key , int count = 1)
        {
            if(IsMenuHasProduct(key))
            {
                _menu[FindSameProduct(key)] += count;
            }
            else
            {
                AddFoodToMenu(key.Name, count, key.Price);
            }
        }

        private bool IsMenuHasProduct(Product product)
        {
            return _menu.All(_product => _product.Key.Name == product.Name);
        }

        private Product FindSameProduct(Product product)
        {
            return _menu.First(_product => _product.Key.Name == product.Name).Key;
        }

    }
}
