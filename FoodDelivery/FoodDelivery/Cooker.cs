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
        public Cooker(string username, string password) : base(username, password)
        {
            _menu = new Dictionary<Product, int>();
        }

        public void AddFoodToMenu(Product product,int count = 1)
        {
            if(IsMenuHasProduct(product))
            {
                _menu[FindSameProductInMenu(product)] += count;
            }
            else
            {
                _menu.Add(product, count);
            }
        }

        private bool IsMenuHasProduct(Product product)
        {
            Product temp = _menu.FirstOrDefault(_product => _product.Key.Name == product.Name).Key;
            if(temp is null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void DecreaseProductCountFromMenu(Product product, int count = 1)
        {
            if(IsMenuHasProduct(product))
            {
                _menu[FindSameProductInMenu(product)] -= count;
                if (_menu[FindSameProductInMenu(product)] <= 0)
                {
                    _menu.Remove(FindSameProductInMenu(product));
                }
            }
        }

        private void RemoveProductFromMenu(Product product)
        {
            if(IsMenuHasProduct(product))
            {
                _menu.Remove(product);
            }
            else
            {
                return;
            }
        }

        private Product FindSameProductInMenu(Product product)
        {
           return _menu.FirstOrDefault(_product => _product.Key.Name == product.Name).Key;
        }

        public Dictionary<Product,int> GetMenu()
        {
            return _menu;
        }
    }
}
