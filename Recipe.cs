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
        public int buyChance;

        public Recipe(int lemonsIn, int sugarCubesIn, int iceCubesIn, double pricePerCupIn)
        {
            amountOfLemons = lemonsIn;
            amountOfSugarCubes = sugarCubesIn;
            amountOfIceCubes = iceCubesIn;
            pricePerCup = pricePerCupIn;
        }

        public void SetBuyChance()
        {
            
        }
    }
}
