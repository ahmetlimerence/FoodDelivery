using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery
{
    public abstract class User
    {
        protected string _username;
        protected string _password;

        public User(string username,string password)
        {
            _username = username;
            _password = password;
        }
    }
}
