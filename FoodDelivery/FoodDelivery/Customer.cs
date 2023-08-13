using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery
{
    internal class Customer :User
    {
        Dictionary<Product,int> _basket;
        public double Balance { get; private set; }
        public Customer(string username,string password)
        {
            _username = username;
            _password = password;
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

        private void AddToBasket(Product product)
        {
            if(!_basket.TryAdd(product,1))
            {
                _basket[product] += 1;
            }
        }
    }
}
