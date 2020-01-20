using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    abstract class Player
    {
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;
        public double profit;
        public int customersServed = 0;

        public Player()
        {
            
            inventory = new Inventory();
            wallet = new Wallet(20);
        }

        public abstract void SetRecipe();

        //The FillNewPitcher method follows the single use principle because
        //as a function it is only used for a single task which is 
        //removing the ingredients give by your recipe from your inventory
        //to "create a new full pitcher object".
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

        //The CalculateUsage method follows the single use principle beacause
        //as a function it only performs a single taskm which is
        //decrementing your daily profit based on the price of the 
        //ingredients you used that day.
        public void CalculateUsage(int pitchersMade, Store store)
        {
            profit -= store.pricePerLemon * pitchersMade * recipe.amountOfLemons;
            profit -= store.pricePerSugarCube * pitchersMade * recipe.amountOfSugarCubes;
            profit -= store.pricePerIceCube * pitchersMade * recipe.amountOfIceCubes;
            profit -= store.pricePerCup * customersServed;
        }

        public abstract void GoShopping(Store store, Day day);
    }
}
