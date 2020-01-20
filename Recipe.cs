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
        private int perfectLemons = 3;
        private int perfectSugar = 4;
        private int perfectIce = 5;
        private double perfectPrice = .25;

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
            double dif = Math.Abs(perfectLemons - amountOfLemons);
            buyChance -= dif * 25;
            dif = Math.Abs(perfectSugar - amountOfSugarCubes);
            buyChance -= dif * 25;
            dif = Math.Abs(perfectIce - amountOfIceCubes);
            buyChance -= dif * 25;
            dif = pricePerCup - perfectPrice;
            buyChance -= dif * 100;
        }
    }
}
