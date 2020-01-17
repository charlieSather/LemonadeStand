using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Store
    {
        public double pricePerLemon;
        public double pricePerSugarCube;
        public double pricePerIceCube;
        public double pricePerCup;

        public Store()
        {
            pricePerLemon = 0.05;
            pricePerSugarCube = 0.02;
            pricePerIceCube = 0.01;
            pricePerCup = 0.02;
        }

        public void RandomizePrices()
        {


        }

        public void SetPrices(double lemonPrice, double sugarCubePrice, double iceCubePrice, double cupPrice)
        {
            pricePerLemon = lemonPrice;
            pricePerSugarCube = sugarCubePrice;
            pricePerIceCube = iceCubePrice;
            pricePerCup = cupPrice;
        }

        public double BulkLemonPrice(int numberOfLemons)
        {
            return pricePerLemon * numberOfLemons;
        }
        public double BulkSugarPrice(int numberOfSugarCubes)
        {
            return pricePerSugarCube * numberOfSugarCubes;
        }
        public double BulkIcePrice(int numberOfCubes)
        {
            return pricePerIceCube * numberOfCubes;
        }
        public double BulkCupPrice(int numberOfCups)
        {
            return pricePerCup* numberOfCups;
        }

        public void Shop(Player player, Day day)
        {
            int menuChoice = Interface.ShopMenu(player, day);

            switch(menuChoice)
            {
                case 1:
                    int lemonsBought = Interface.BuyLemons();
                    if (player.wallet.money > BulkLemonPrice(lemonsBought))
                    {
                        player.wallet.SpendMoney(BulkLemonPrice(lemonsBought));
                        player.inventory.AddLemons(lemonsBought);
                    }
                    Shop(player, day);
                    break;
                case 2:
                    int sugarBought = Interface.BuySugar();
                    if (player.wallet.money > BulkSugarPrice(sugarBought))
                    {
                        player.wallet.SpendMoney(BulkSugarPrice(sugarBought));
                        player.inventory.AddSugarCubes(sugarBought);
                    }
                    Shop(player, day);
                    break;
                case 3:
                    int iceBought = Interface.BuyIce();
                    if (player.wallet.money > BulkIcePrice(iceBought))
                    {
                        player.wallet.SpendMoney(BulkIcePrice(iceBought));
                        player.inventory.AddIceCubes(iceBought);
                    }
                    Shop(player, day);
                    break;
                case 4:
                    int cupsBought = Interface.BuyCups();
                    if (player.wallet.money > BulkCupPrice(cupsBought))
                    {
                        player.wallet.SpendMoney(BulkCupPrice(cupsBought));
                        player.inventory.AddCups(cupsBought);
                    }
                    Shop(player, day);
                    break;
                case 5:
                    break;
            }
        }
    }
}
