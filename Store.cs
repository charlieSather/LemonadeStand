using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Store
    {
        double pricePerLemon;
        double pricePerSugarCube;
        double pricePerIceCube;
        double pricePerCup;

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

        public void BulkBuy(Player player, Item item, int numOfItems)
        {
            switch (item.name)
            {
                case ("Lemon"):
                    if (player.wallet.CheckMoney(BulkLemonPrice(numOfItems)))
                    {
                        player.wallet.SpendMoney(BulkLemonPrice(numOfItems));
                        player.inventory.AddLemons(numOfItems);                        
                    }
                    break;
                case ("Sugar Cube"):
                    if (player.wallet.CheckMoney(BulkSugarPrice(numOfItems)))
                    {
                        player.wallet.SpendMoney(BulkSugarPrice(numOfItems));
                        player.inventory.AddSugarCubes(numOfItems);
                    }
                   
                    break;
                case ("Ice Cube"):
                    if(player.wallet.CheckMoney(BulkIcePrice(numOfItems)))
                    {
                        player.wallet.SpendMoney(BulkIcePrice(numOfItems));
                        player.inventory.AddIceCubes(numOfItems);
                    }
                    break;
                case ("Cup"):
                    if (player.wallet.CheckMoney(BulkCupPrice(numOfItems)))
                    {
                        player.wallet.SpendMoney(BulkCupPrice(numOfItems));
                        player.inventory.AddCups(numOfItems);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
