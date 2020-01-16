using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Player
    {
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;

        public Player(string name)
        {
            this.name = name;
            inventory = new Inventory();
            wallet = new Wallet(20);
            pitcher = new Pitcher();
        }

        public void SetRecipe(int lemonsIn, int sugarIn, int iceIn, double priceIn)
        {
            recipe = new Recipe(lemonsIn, sugarIn, iceIn, priceIn);
        }

        public void Shop()
        {

        }

        public void FillNewPitcher()
        {
            pitcher = new Pitcher();
            if (inventory.lemons.Count > recipe.amountOfLemons)
            {
                inventory.lemons.RemoveRange(0, recipe.amountOfLemons);
            }
            if (inventory.sugarCubes.Count > recipe.amountOfSugarCubes)
            {
                inventory.sugarCubes.RemoveRange(0, recipe.amountOfSugarCubes);
            }
            if (inventory.iceCubes.Count > recipe.amountOfIceCubes)
            {
                inventory.iceCubes.RemoveRange(0, recipe.amountOfIceCubes);
            }
        }


    }
}
