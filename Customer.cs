using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Customer
    {
        public string name { get; set; }

        public Customer(string name)
        {
            this.name = name;
        }

        public Customer()
        {
            name = "Customer";
        }

        public bool CheckIfBuy(Weather weather, Recipe recipe)
        {
            bool willBuy = false;

            //TODO

            return willBuy;
        }

        public int DetermineNumberOfCustomers(Weather weather)
        {
            int numCustomers = 0;

            switch (weather.condition)
            {
                case ("Sunny"):
                    numCustomers = 50;
                    break;
                case ("Cloudy"):
                    numCustomers = 40;
                    break;
                case ("Rainy"):
                    numCustomers = 15;
                    break;
                case ("Stormy"):
                    numCustomers = 5;
                    break;
                case ("Snowing"):
                    numCustomers = 5;
                    break;
                case ("Windy"):
                    numCustomers = 20;
                    break;
                case ("Icy"):
                    numCustomers = 10;
                    break;
                default:
                    //INterface couldn't match current weather's condition
                    break;
            }
            return numCustomers;
        }
    }
}
