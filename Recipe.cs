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
        public int amoutnOfIceCubes;
        public double pricePerCup;

        public Recipe(int lemonsIn, int sugarCubesIn, int iceCubesIn, int pricePerCupIn)
        {
            amountOfLemons = lemonsIn;
            amountOfSugarCubes = sugarCubesIn;
            amoutnOfIceCubes = iceCubesIn;
            pricePerCup = pricePerCupIn;
        }


    }
}
