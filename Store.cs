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

        public void BuyItem(Wallet wallet)
        {

        }



    }
}
