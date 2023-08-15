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
        public Dictionary<Product, int> _basket;
        private double _balance;

        public Customer(string username, string password) : base(username, password)
        {
            _basket = new Dictionary<Product, int>();
        }

       

        private bool IsBasketValid(Dictionary<Product,int> basket)
        {
            if (basket.Count > 0)
            {
                string cookerName = basket.First().Key.CookerUserName;
                return (basket.All(Product => Product.Key.CookerUserName == cookerName));
            }
            return false;
           
        }

        public void AddProduct(Product product)
        {
            if (IsBasketHasProduct(product))
            {
                var p = FindSameProduct(product);

                if (p != null)
                    _basket[p]++;
                else
                {
                    _basket.Add(product, 1);
                    return;
                }
            }
           
        }

        private void RemoveProduct(Product product)
        {
            if(IsBasketHasProduct(product))
            {
                _basket[FindSameProduct(product)]--;
                if (_basket[FindSameProduct(product)] < 1)
                {
                    _basket.Remove(FindSameProduct(product));
                }
            }
        }
       
        public void LoadBalance(double amounth)
        {
            if (amounth > 0)
                _balance += amounth;
            else
                throw new Exception("Amounth is not valid");
        }

        

        private bool IsBasketHasProduct(Product product)
        {
            return _basket.All(_product => _product.Key.Name == product.Name);
        }

        private Product FindSameProduct(Product product)
        {
            Console.WriteLine(_basket.FirstOrDefault(_product => _product.Key.Name == product.Name));

            return _basket.FirstOrDefault(_product => _product.Key.Name == product.Name).Key;
        }

        public double SumOfBasket()
        {
            double sum = 0;
            foreach (Product product in _basket.Keys)
            {
                sum += (product.Price * _basket[FindSameProduct(product)]);
            }
            return sum;

        }

     
       
    }
}
