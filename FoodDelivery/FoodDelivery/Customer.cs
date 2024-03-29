﻿using System;
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
        Dictionary<Product,int> _basket;
        private double _balance;

        public Customer(string username, string password) : base(username, password)
        {

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

        private void AddProduct(Product product)
        {
            if (IsBasketHasProduct(product))
            {
                _basket[FindSameProduct(product)]++;
            }
            else
                return;
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

        public void MakePayment(Cooker cooker, double amounth)
        {
            if(this._balance >= amounth)
            {
                cooker.GetPayment(amounth);
            }
            else
                throw new Exception("No  Money");
        }

        private bool IsBasketHasProduct(Product product)
        {
            return _basket.All(_product => _product.Key.Name == product.Name);
        }

        private Product FindSameProduct(Product product)
        {
            return _basket.First(_product => _product.Key.Name == product.Name).Key;
        }

       
    }
}
