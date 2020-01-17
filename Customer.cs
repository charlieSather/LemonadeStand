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

            double averageBuyChance = (weather.buyChance + recipe.buyChance + buyChance) / 3;

            if(MyRandom.Next(1, 101) < averageBuyChance)
            {
                willBuy = true;
            }

            return willBuy;
        }

        public void BuyLemonade(Player player)
        {
            Interface.CustomerPurchase(this);
            player.wallet.Money += player.recipe.pricePerCup;
            player.profit += player.recipe.pricePerCup;
            player.pitcher.PourCup(player.inventory);
            player.customersServed++;
        }

        public void SetBuyChance()
        {
            buyChance = MyRandom.Next(30, 75);
        }
    }
}
