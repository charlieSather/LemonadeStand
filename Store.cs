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

        public void BuyItem(Player player, Item item)
        {
            switch (item.name)
            {
                case ("Lemon"):
                    if(player.wallet.money > pricePerLemon)
                    {
                        player.wallet.SpendMoney(pricePerLemon);
                    }
                    break;
                case ("SugarCube"):
                    if (player.wallet.money > pricePerSugarCube)
                    {
                        player.wallet.SpendMoney(pricePerSugarCube);
                    }
                    break;
                case ("IceCube"):
                    if (player.wallet.money > pricePerIceCube)
                    {
                        player.wallet.SpendMoney(pricePerIceCube);
                    }
                    break;
                case ("Cup"):
                    if (player.wallet.money > pricePerCup)
                    {
                        player.wallet.SpendMoney(pricePerCup);
                    }
                    break;
                default:
                    //CWL some message
                    break;
            }
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
                    if (player.wallet.money > BulkLemonPrice(numOfItems))
                    {
                        player.wallet.SpendMoney(BulkLemonPrice(numOfItems));
                        player.inventory.AddLemons(numOfItems);                        
                    }
                    break;
                case ("SugarCube"):
                    if (player.wallet.money > BulkSugarPrice(numOfItems))
                    {
                        player.wallet.SpendMoney(BulkSugarPrice(numOfItems));
                        player.inventory.AddSugarCubes(numOfItems);
                    }
                   
                    break;
                case ("IceCube"):
                    if(player.wallet.money > BulkIcePrice(numOfItems))
                    {
                        player.wallet.SpendMoney(BulkIcePrice(numOfItems));
                        player.inventory.AddIceCubes(numOfItems);
                    }
                    break;
                case ("Cup"):
                    if (player.wallet.money > BulkCupPrice(numOfItems))
                    {
                        player.wallet.SpendMoney(BulkCupPrice(numOfItems));
                        player.inventory.AddCups(numOfItems);
                    }
                    break;
                default:
                    break;
            }
        }

        public double GetLemonPrice()
        {
            return pricePerLemon;
        }

        public double GetSugarCubePrice()
        {
            return pricePerSugarCube;
        }

        public double GetIceCubePrice()
        {
            return pricePerSugarCube;
        }
        public double GetCupPrice()
        {
            return pricePerCup;
        }



    }
}
