using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Computer : Player
    {

        private int perfectLemons = 3;
        private int perfectSugar = 4;
        private int perfectIce = 5;
        private double perfectPrice = .25;
        public Computer()
        {
            name = "Jarvis";
            SetRecipe();
        }

        public override void SetRecipe()
        {
            if(recipe == null)
            {
                recipe = new Recipe(Brain(perfectLemons), Brain(perfectSugar), Brain(perfectIce), Brain(perfectPrice));
            }
        }

        private int Brain(int input)
        {
            int thoughts;

            thoughts = MyRandom.Next(input - 1, input + 1);

            return thoughts;
        }

        private double Brain(double input)
        {
            double thoughts;

            thoughts = MyRandom.Next((Convert.ToInt32(input * 100) + 5) - (Convert.ToInt32(input * 100) - 5));

            thoughts /= 100;

            return thoughts;
        }

        private int InsiderKnowledge(int temperature)
        {
            int demand;
            if (temperature >= 90)
            {
                demand = 5;
            }
            else if (temperature >= 80 && temperature < 90)
            {
                demand = 4;
            }
            else if (temperature >= 60 && temperature < 80)
            {
                demand = 3;
            }
            else if (temperature >= 40 && temperature < 60)
            {
                demand = 2;
            }else
            {
                demand = 1;
            }
            return demand;
        }

        public override void GoShopping(Store store, Day day)
        {
            int demand = InsiderKnowledge(day.weather.temperature);

            int buy = recipe.amountOfLemons;
            if (inventory.lemons.Count < demand * buy && wallet.Money > demand * store.BulkLemonPrice(buy))
            {
                wallet.SpendMoney(store.BulkLemonPrice(buy));
                inventory.AddLemons(demand * buy);
                Interface.ComputerPurchase("Lemon", demand * buy, name);
            }
            else if(inventory.lemons.Count < recipe.amountOfLemons)
            {
                wallet.SpendMoney(recipe.amountOfLemons - inventory.lemons.Count);
                inventory.AddLemons(recipe.amountOfLemons - inventory.lemons.Count);
                Interface.ComputerPurchase("Lemon", recipe.amountOfLemons - inventory.lemons.Count, name);
            }

            buy = recipe.amountOfSugarCubes;
            if (inventory.sugarCubes.Count < demand * buy && wallet.Money > demand * store.BulkSugarPrice(buy))
            {
                wallet.SpendMoney(store.BulkSugarPrice(buy));
                inventory.AddSugarCubes(demand * buy);
                Interface.ComputerPurchase("Sugar Cube", demand * buy, name);
            }
            else if (inventory.sugarCubes.Count < recipe.amountOfSugarCubes)
            {
                wallet.SpendMoney(recipe.amountOfSugarCubes - inventory.sugarCubes.Count);
                inventory.AddSugarCubes(recipe.amountOfSugarCubes - inventory.sugarCubes.Count);
                Interface.ComputerPurchase("Sugar Cube", recipe.amountOfSugarCubes - inventory.sugarCubes.Count, name);
            }

            buy = recipe.amountOfIceCubes;
            if (inventory.iceCubes.Count < demand * buy && wallet.Money > demand * store.BulkIcePrice(buy))
            {
                wallet.SpendMoney(store.BulkIcePrice(buy));
                inventory.AddIceCubes(demand * buy);
                Interface.ComputerPurchase("Ice Cube", demand * buy, name);
            }
            else if (inventory.iceCubes.Count < recipe.amountOfIceCubes)
            {
                wallet.SpendMoney(recipe.amountOfIceCubes - inventory.iceCubes.Count);
                inventory.AddIceCubes(recipe.amountOfIceCubes - inventory.iceCubes.Count);
                Interface.ComputerPurchase("Ice Cube", recipe.amountOfSugarCubes - inventory.iceCubes.Count, name);
            }

            buy = demand * 10;
            if (inventory.cups.Count < demand * buy && wallet.Money > demand * store.BulkCupPrice(buy))
            {
                wallet.SpendMoney(store.BulkCupPrice(buy));
                inventory.AddCups(demand * buy);
                Interface.ComputerPurchase("Cup", demand * buy, name);
            }
            else if (inventory.cups.Count < 15)
            {
                wallet.SpendMoney(15 - inventory.cups.Count);
                inventory.AddCups(15 - inventory.cups.Count);
                Interface.ComputerPurchase("Cup", 15 - inventory.cups.Count, name);
            }
        }
    }
}
