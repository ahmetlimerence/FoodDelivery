using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodDelivery
{
    internal class Customer :User
    {
        private Dictionary<Product, int> _basket;
        private double _balance;

        public Customer(string username, string password) : base(username, password)
        {
            _basket = new Dictionary<Product, int>();
        }

        public Dictionary<Product, int> GetBasket()
        {
            return _basket;
        }

        public void AddProductToBasket(Product product,int count = 1)
        {
            if (IsBasketHasProduct(product))
            {
                _basket[FindSameProductInBasket(product)] += count;
            }
            else
            {
                _basket.Add(product, count);
            }

        }

        private bool IsBasketHasProduct(Product prodcut)
        {
            Product temp = _basket.FirstOrDefault(_product => _product.Key.Name == prodcut.Name).Key;
            if (temp is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Product FindSameProductInBasket(Product product)
        {
            return _basket.FirstOrDefault(_product => _product.Key.Name == product.Name).Key;
        }
    }
}
