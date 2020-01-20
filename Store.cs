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
            player.GoShopping(this, day);
        }
    }
}
