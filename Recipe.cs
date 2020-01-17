using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Recipe
    {

        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;
        public double buyChance = 100;

        public Recipe(int lemonsIn, int sugarCubesIn, int iceCubesIn, double pricePerCupIn)
        {
            amountOfLemons = lemonsIn;
            amountOfSugarCubes = sugarCubesIn;
            amountOfIceCubes = iceCubesIn;
            pricePerCup = pricePerCupIn;
            SetBuyChance();
        }

        public void SetBuyChance()
        {
            double dif = Math.Abs(3 - amountOfLemons);
            buyChance -= dif * 25;
            dif = Math.Abs(4 - amountOfSugarCubes);
            buyChance -= dif * 25;
            dif = Math.Abs(5 - amountOfIceCubes);
            buyChance -= dif * 25;
            dif = pricePerCup - .25;
            buyChance -= dif * 100;
        }
    }
}
