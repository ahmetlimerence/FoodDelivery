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

        public void LoadBalance(double amounth)
        {
            if (amounth > 0)
                _balance += amounth;
            else
                return;
        }

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

        public void DecreaseProductCount(Product product, int count = 1)
        {
            if (IsBasketHasProduct(product))
            {
                _basket[FindSameProductInBasket(product)] -= count;
                if (_basket[FindSameProductInBasket(product)] <= 0)
                {
                    DeleteProductFromBasket(product);
                }
            }
        }

        public void DeleteProductFromBasket(Product product)
        {
            if(IsBasketHasProduct(product))
            {
                _basket.Remove(FindSameProductInBasket(product));
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

        public void MakePayment(Cooker cooker, double amounth)
        {
            cooker.GetPayment(amounth);
        }

        private bool IsBasketValid()
        {
            if(_basket.Count > 0)
            {
                Cooker temp = _basket.First().Key.Cooker;
                foreach (var item in _basket.Keys) 
                { 
                    if(item.Cooker != temp)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private double GetSumTotalBasket()
        {
            double sum = 0;
            foreach (var item in _basket.Keys) 
            {
                sum += (item.Price * _basket[item]);
            }
            return sum;
        }

        public void CheckOut()
        {
            if (IsBasketValid())
            {
                Cooker temp = _basket.First().Key.Cooker;
                MakePayment(temp, GetSumTotalBasket());
            }
            else
                return;
        }
    }
}
