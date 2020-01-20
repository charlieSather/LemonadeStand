using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Human : Player
    {
        public Human(string name)
        {
            this.name = name;
        }

        public override void SetRecipe()
        {
            (int, int, int, double) recipe = Interface.GetRecipe(this);
            this.recipe = new Recipe(recipe.Item1, recipe.Item2, recipe.Item3, recipe.Item4);
        }

        public override void GoShopping(Store store, Day day)
        {
            int menuChoice = Interface.ShopMenu(this, day);

            switch (menuChoice)
            {
                case 1:
                    int lemonsBought = Interface.BuyLemons();
                    if (wallet.Money > store.BulkLemonPrice(lemonsBought))
                    {
                        wallet.SpendMoney(store.BulkLemonPrice(lemonsBought));
                        inventory.AddLemons(lemonsBought);
                    }
                    GoShopping(store, day);
                    break;
                case 2:
                    int sugarBought = Interface.BuySugar();
                    if (wallet.Money > store.BulkSugarPrice(sugarBought))
                    {
                        wallet.SpendMoney(store.BulkSugarPrice(sugarBought));
                        inventory.AddSugarCubes(sugarBought);
                    }
                    GoShopping(store, day);
                    break;
                case 3:
                    int iceBought = Interface.BuyIce();
                    if (wallet.Money > store.BulkIcePrice(iceBought))
                    {
                        wallet.SpendMoney(store.BulkIcePrice(iceBought));
                        inventory.AddIceCubes(iceBought);
                    }
                    GoShopping(store, day);
                    break;
                case 4:
                    int cupsBought = Interface.BuyCups();
                    if (wallet.Money > store.BulkCupPrice(cupsBought))
                    {
                        wallet.SpendMoney(store.BulkCupPrice(cupsBought));
                        inventory.AddCups(cupsBought);
                    }
                    GoShopping(store, day);
                    break;
                case 5:
                    break;
            }
        }
    }
}
