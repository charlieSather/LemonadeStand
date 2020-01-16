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
        int buyChance;

        public Customer(string name)
        {
            this.name = name;
            SetBuyChance();
        }

        public Customer()
        {
            name = "Customer";
        }

        public bool CheckIfBuy(Weather weather, Recipe recipe)
        {
            bool willBuy = false;

            int averageBuyChance = (int) (weather.buyChance * recipe.buyChance * buyChance) / 3;

            //int averageInt = (int) average;

            //call static random 

            //Random number returned has to overcome the averageBuyChance in order to overturn customer's decision to not buy
            if(MyRandom.Next(1, 101) < averageBuyChance)
            {
                willBuy = true;
            }

            return willBuy;
        }

        public void BuyLemonade(Player player, double price)
        {
            player.wallet.money += price;
        }

        public void BuyLemonade()
        {
            //Interface.BuyLemonade(name)
            //Interface.ThankPlayer(name)
        }
        public void SetBuyChance()
        {
            //Random rand = new Random();

            buyChance = MyRandom.Next(30, 101);

            //buyChance = rand.Next(30, 101);
            //buyChance = rand.Next(101);
        }


        public int DetermineNumberOfCustomers(Weather weather)
        {
            int numCustomers = 0;

            switch (weather.predictedForecast)
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
