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
        public double profit;
        public int customersServed = 0;

        public Player(string name)
        {
            this.name = name;
            inventory = new Inventory();
            wallet = new Wallet(20);
        }

        public void SetRecipe()
        {
            (int, int, int, double) recipe = Interface.GetRecipe(this);
            this.recipe = new Recipe(recipe.Item1, recipe.Item2, recipe.Item3, recipe.Item4);
        }

        public void FillNewPitcher()
        {
            pitcher = new Pitcher();
            if (inventory.lemons.Count >= recipe.amountOfLemons)
            {
                inventory.lemons.RemoveRange(0, recipe.amountOfLemons);
            }
            if (inventory.sugarCubes.Count >= recipe.amountOfSugarCubes)
            {
                inventory.sugarCubes.RemoveRange(0, recipe.amountOfSugarCubes);
            }
            if (inventory.iceCubes.Count >= recipe.amountOfIceCubes)
            {
                inventory.iceCubes.RemoveRange(0, recipe.amountOfIceCubes);
            }
        }

        public void CalculateUsage(int pitchersMade, Store store)
        {
            profit -= store.pricePerLemon * pitchersMade * recipe.amountOfLemons;
            profit -= store.pricePerSugarCube * pitchersMade * recipe.amountOfSugarCubes;
            profit -= store.pricePerIceCube * pitchersMade * recipe.amountOfIceCubes;
            profit -= store.pricePerCup * customersServed;
        }

    }
}
